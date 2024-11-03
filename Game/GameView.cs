using ConsoleDungeon.Abstruct;
using ConsoleDungeon.Game.Parameter;
using ConsoleDungeon.Game.World;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDungeon.Game
{
    internal class GameView: View
    {
        const int _uiAreaRow = 3, _uiAreaCol = 17;
        const int _windowRow = 3, _windowCol = 5;

        public GameView() : base(25, 30) { }

        public void ToNextFrame(Score score, Map map, Player player)
        {
            DrawUI(3, 9, $"{score}");
            DrawWorld(map);
            DrawInWorld(player.NowLoc.Row, player.NowLoc.Col, player.Symbol.ToString());
        }

        void DrawUI(int row, int col, string item)
        {
            Console.WriteLine($"\x1b[{_uiAreaRow + row};{_uiAreaCol + col}H{item}");
        }

        void DrawInWorld(int row, int col, string item)
        {
            Console.WriteLine($"\x1b[{_windowRow + row};{_windowCol + col}H{item}");
        }

        void DrawWorld(Map map)
        {
            for(int i = 0; i < Map.RowLength; i++) { DrawInWorld(i, 0, map.GetLine(new MapIndex(i))); }
        }

        public void DrawPlayerMovement(Player player, Map map)
        {
            DrawInWorld(player.OldLoc.Row, player.OldLoc.Col, map.GetSymbol(player.OldLoc).ToString());
            DrawInWorld(player.NowLoc.Row, player.NowLoc.Col, player.Symbol.ToString());
        }

        public void DrawMiss()
        {
            DrawUI(7, 2, "MISS!");
            DrawUI(8, 2, "Press Enter");
        }

        public void CreateWindow(GameParameter param, Map map)
        {
            DrawUI(3, 2, $"SCORE: {param.Score}");
            DrawUI(4, 2, $"LIFE: {param.Life}");
            DrawWorldWall(map, 1);
        }

        // リファクタリング希望
        void DrawWorldWall(Map map, int frameSize)
        {
            var horizontalWall = new string('-', Map.ColLength + frameSize * 2);
            var verticalWall = $"|{new string(' ', Map.ColLength)}|";
            DrawInWorld(-1, -1, horizontalWall);
            DrawInWorld(Map.RowLength, -1, horizontalWall);
            for (int i = 0; i < Map.RowLength; i++) { DrawInWorld(i, -1, verticalWall); }
        }
    }
}
