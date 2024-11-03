using ConsoleDungeon.Abstruct;
using ConsoleDungeon.Game.Control;
using ConsoleDungeon.Game.Parameter;
using ConsoleDungeon.Game.World;
using ConsoleDungeon.Title;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace ConsoleDungeon.Game
{
    internal class GameViewModel: ViewModel
    {
        readonly Map _map = new();
        readonly GameView _view = new();
        readonly Player _player = new();
        readonly GameController _controller = new();
        readonly GameParameter _param;

        public GameViewModel(GameParameter param)
        {
            _view.CreateWindow(param, _map);
            _param = param;
        }

        // Update()の実行中は操作を受け付けないようにしないと
        public override ViewModel Execute()
        {
            _timer.Start();
            while(!_map.CanKill(_player))
            {
                if (Console.KeyAvailable)
                {
                    Command command = _controller.GetInputResult(Console.ReadKey(true).Key);
                    _player.Move(command);
                    _view.DrawPlayerMovement(_player, _map);
                }
            }
            _timer.Stop();
            _view.DrawMiss();
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
            return CreateNextViewModel();
        }

        ViewModel CreateNextViewModel()
        {
            _view.CleanWindow();
            if(!_param.IsLastGame()) { return new GameViewModel(_param.GetNext()); }
            return new TitleViewModel();
        }

        protected override void ToNextFrame()
        {
            _map.ToNextFrame(_player);
            _player.ToNextFrame();
            _param.ToNextFrame();
            _view.ToNextFrame(_param.Score, _map, _player);
        }
    }
}
