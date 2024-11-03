using ConsoleDungeon.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace ConsoleDungeon.Abstruct
{
    internal abstract class ViewModel
    {
        protected readonly Timer _timer = new Timer(1000);

        protected ViewModel() => _timer.Elapsed += (s, e) => ToNextFrame();

        public abstract ViewModel Execute();

        protected abstract void ToNextFrame();
    }
}
