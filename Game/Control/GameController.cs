using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDungeon.Game.Control
{
    internal class GameController
    {
        Dictionary<ConsoleKey, Command> _sample = new() 
        { 
            { ConsoleKey.A, Command.LEFT }, { ConsoleKey.D, Command.RIGHT }, 
            { ConsoleKey.W, Command.UP }, { ConsoleKey.S, Command.DOWN } 
        };

        public Command GetInputResult(ConsoleKey key)
        {
            if (!_sample.ContainsKey(key)) { return Command.NONE; }
            return _sample[key];
        }
    }
}
