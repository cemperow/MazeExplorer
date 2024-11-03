using ConsoleDungeon.Game.Control;
using ConsoleDungeon.Game.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDungeon.Game.Parameter
{
    // 事実上列挙型みたいになっている
    internal class Vector
    {
        readonly static Vector _up = new Vector(-1, 0);
        readonly static Vector _down = new Vector(1, 0);
        readonly static Vector _left = new Vector(0, -1);
        readonly static Vector _right = new Vector(0, 1);
        readonly static Vector _none = new Vector(0, 0);

        public int Row { get; }
        public int Col { get; }

        static readonly Dictionary<Command, Vector> _movingVector = new()
        {
            { Command.LEFT, _left }, { Command.RIGHT, _right },
            { Command.UP, _up }, { Command.DOWN, _down },
            { Command.NONE, _none }
        };

        Vector(int row, int col) => (Row, Col) = (row, col);

        public static Vector Get(Command command) => _movingVector[command];

        public static List<Vector> GetAll() => new List<Vector>() { _up, _down, _left, _right };
    }
}
