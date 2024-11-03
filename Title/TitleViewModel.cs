using ConsoleDungeon.Abstruct;
using ConsoleDungeon.Game;
using ConsoleDungeon.Game.Control;
using ConsoleDungeon.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDungeon.Title
{
    internal class TitleViewModel : ViewModel
    {
        readonly TitleView _view = new();

        readonly Dictionary<ConsoleKey, bool> _isStart = new()
        {
            { ConsoleKey.Enter, true },
            { ConsoleKey.Escape, false }
        };

        bool IsStart()
        {
            while (true)
            {
                if (!Console.KeyAvailable) { continue; }
                ConsoleKey input = Console.ReadKey(true).Key;
                if (_isStart.ContainsKey(input)) { return _isStart[input]; }
            }
        }

        public override ViewModel Execute()
        {
            bool isStart = IsStart();
            _view.CleanWindow();
            if (isStart) { return new GameViewModel(GameParameter.GetFirst()); }
            else { return new EndBase(); }
        }

        protected override void ToNextFrame() { }
    }
}
