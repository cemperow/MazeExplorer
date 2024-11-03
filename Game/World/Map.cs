using ConsoleDungeon.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDungeon.Game.World
{
    internal class Map
    {
        public static int RowLength { get; } = 10;
        public static int ColLength { get; } = 10;

        Symbol[][] _map = Enumerable.Range(0, RowLength).Select(i => Enumerable.Repeat(Symbol.Space, ColLength).ToArray()).ToArray();

        public bool[] MakeMovableLine(Player player)
        {
            bool[][] deathZone = _map.Select(i => i.Select(j => j.CanKill).ToArray()).ToArray();
            Queue<Location> checkingLoc = new(new Location[] {player.NowLoc});
            deathZone[player.NowLoc.Row][player.NowLoc.Col] = true;
            List<Location> last = new();

            while (checkingLoc.Count > 0)
            {
                var now = checkingLoc.Dequeue();
                List<Location> neighbors = now.Make4Neighbors();
                foreach (var neighbor in neighbors)
                {
                    if (!deathZone[neighbor.Row][neighbor.Col])
                    {
                        deathZone[neighbor.Row][neighbor.Col] = true;
                        checkingLoc.Enqueue(neighbor);
                        if (neighbor.Row == RowLength - 1) { last.Add(neighbor); }
                    }
                }
            }

            Random rand = new();
            bool[] answer = Enumerable.Range(0, ColLength).Select(i => rand.NextDouble() >= 0.5).ToArray();
            answer[last[rand.Next(last.Count)].Col] = true;
            return answer;
        }

        Symbol[][] CreateNextMap(Player player)
        {
            Symbol[][] _newMap = new Symbol[RowLength][];
            for(int i = 1; i < RowLength; i++) { _newMap[i - 1] = _map[i]; }
            _newMap[RowLength - 1] = MakeMovableLine(player).Select(i => i ? Symbol.Space : Symbol.Wall).ToArray();
            return _newMap;
        }

        public void ToNextFrame(Player player) => _map = CreateNextMap(player);

        public string GetLine(MapIndex row)
        {
            return String.Join("",_map[row.Row].Select(i => i.ToString()));
        }

        public Symbol GetSymbol(Location loc) => _map[loc.Row][loc.Col];

        public bool CanKill(Player player) => _map[player.NowLoc.Row][player.NowLoc.Col].CanKill;
    }
}
