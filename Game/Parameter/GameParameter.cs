using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDungeon.Game.Parameter
{
    internal class GameParameter
    {
        public Score Score { get; private set; }
        public Life Life { get; }

        GameParameter(Life life, Score score)
        {
            Life = life;
            Score = score;
        }

        public static GameParameter GetFirst() => new GameParameter(Life.FirstLife, Score.FirstScore);

        public GameParameter GetNext() => new GameParameter(Life.Reduce(), Score);

        public void ToNextFrame() => Score = Score.ToNextFrame();

        public bool IsLastGame() => Life.IsLast();
    }
}
