using ConsoleDungeon.Game.Control;
using ConsoleDungeon.Game.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDungeon.Game.Parameter
{
    internal class Player
    {
        public Location NowLoc { get; private set; } = Location.FirstPlayerLoc;
        public Location OldLoc { get; private set; } = Location.FirstPlayerLoc;
        public Symbol Symbol { get; } = Symbol.Player;

        public void Move(Command command)
        {
            Vector vec = Vector.Get(command);
            OldLoc = NowLoc;
            NowLoc = NowLoc.Move(vec);
        }

        public void ToNextFrame() => Move(Command.UP);
    }
}
