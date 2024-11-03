using ConsoleDungeon.Abstruct;
using ConsoleDungeon.Game.Parameter;
using ConsoleDungeon.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDungeon.Title
{
    internal class TitleView: View
    {
        const string _title = "\x1b[1;1H壁除けゲーム\n";
        const string _objectIntroduction = "オブジェクト説明\n@ -> プレイヤー\n# -> 壁\n";
        const string _operationIntroduction = "操作説明\nW -> 上\nS -> 下\nA -> 左\nD -> 右\n";
        const string _rule = "壁を避けて進んでください\nENTERキーで開始します\nESCキーで終了します\n";

        public TitleView() : base(25, 30) => CreateBase();

        void CreateBase()
        {
            string display =
                $"{_title}\n{_objectIntroduction}\n" +
                $"{_operationIntroduction}\n{_rule}";
            Console.WriteLine(display);
        }
    }
}
