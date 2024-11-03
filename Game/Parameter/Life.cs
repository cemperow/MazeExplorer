using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDungeon.Game.Parameter
{
    internal class Life
    {
        public static Life FirstLife { get; } = new Life(_max);

        const int _min = 1;
        const int _max = 3;

        readonly int _val;

        Life(int life) => _val = life;

        public override string ToString() => $"{_val}";

        public bool IsLast() => _val == _min;

        public Life Reduce() => new Life(_val - 1);
    }
}
