using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDungeon.Game
{
    internal class Symbol
    {
        public static Symbol Wall { get; } = new Symbol('#', "", true);
        public static Symbol Space { get; } = new Symbol(' ', "", false);
        public static Symbol Player { get; } = new Symbol('@', "", false);

        readonly char _symbol;
        readonly string _color;

        public bool CanKill { get; }

        Symbol(char symbol, string color, bool canKill)
        {
            _symbol = symbol;
            _color = color;
            CanKill = canKill;
        }

        public override string ToString() => $"{_color}{_symbol}";
    }
}
