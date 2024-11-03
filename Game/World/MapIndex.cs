using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDungeon.Game.World
{
    internal class MapIndex
    {
        static readonly int _rowLength = Map.RowLength;
        static readonly int _colLength = Map.ColLength;

        public int Row { get; }
        public int Col { get; }

        public MapIndex(int row, int col)
        {
            if (row < 0 || row >= _rowLength) { throw new ArgumentOutOfRangeException($"行{row}はマップの範囲を超えています"); }
            if (col < 0 || col >= _colLength) { throw new ArgumentOutOfRangeException($"列{col}はマップの範囲を超えています"); }
            Row = row;
            Col = col;
        }

        public MapIndex(int row)
        {
            if (row < 0 || row >= _rowLength) { throw new ArgumentOutOfRangeException($"行{row}はマップの範囲を超えています"); }
            Row = row;
            Col = 0;
        }
    }
}
