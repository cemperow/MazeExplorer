using ConsoleDungeon.Game.Control;
using ConsoleDungeon.Game.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDungeon.Game.Parameter
{
    internal class Location
    {
        public static Location FirstPlayerLoc { get; } = new Location(3, 3);

        public int Row { get; }
        public int Col { get; }

        Location(int row, int col)
        {
            Row = ModifyRow(row);
            Col = ModifyCol(col);
        }

        Location(Location loc, Vector vec)
        {
            Row = ModifyRow(loc.Row + vec.Row);
            Col = ModifyCol(loc.Col + vec.Col);
        }

        // map.rowlengthをstaticにしないためにはどうすれば
        int ModifyRow(int row)
        {
            int rowMax = Map.RowLength - 1;
            if (row < 0) { return 0; }
            if (row > rowMax) { return rowMax; }
            return row;
        }

        int ModifyCol(int col)
        {
            int colMax = Map.ColLength - 1;
            if (col < 0) { return 0; }
            if (col > colMax) { return colMax; }
            return col;
        }

        public Location Move(Vector vec) => new Location(this, vec);

        public List<Location> Make4Neighbors() => Vector.GetAll().Select(i => Move(i)).ToList();
    }
}
