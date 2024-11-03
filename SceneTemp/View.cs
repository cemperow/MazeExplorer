using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDungeon.Abstruct
{
    internal abstract class View
    {
        readonly int _rowLength;
        readonly int _colLength;

        protected View(int rowLength, int colLength)
        {
            _rowLength = rowLength;
            _colLength = colLength;
        }

        public void CleanWindow()
        {
            string line = $"{new string(' ', _colLength)}\n";
            var blank = $"\x1b[1;1H{string.Concat(Enumerable.Repeat(line, _rowLength))}";
            Console.Write(blank);
        }
    }
}
