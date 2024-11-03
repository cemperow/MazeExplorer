using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDungeon.Game.Parameter
{
    internal class Score
    {
        public static Score FirstScore { get; } = new Score();

        const int _min = 0;

        int _val;

        private Score() => _val = _min;
        private Score(Score prev) => _val = prev._val + 1;

        public override string ToString() => $"{_val}";

        public Score ToNextFrame() => new Score(this);
    }
}
