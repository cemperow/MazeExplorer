using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleDungeon.Abstruct;

namespace ConsoleDungeon
{
    internal class EndBase : ViewModel
    {
        public override ViewModel Execute() => new EndBase();

        protected override void ToNextFrame() { }
    }
}
