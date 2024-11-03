using ConsoleDungeon;
using ConsoleDungeon.Abstruct;
using ConsoleDungeon.Game;
using ConsoleDungeon.Title;
using System.Runtime.InteropServices;

internal class Program
{

    public static void Main()
    {
        Console.Write("\x1b[2J");
        Console.CursorVisible = false;
        ViewModel window = new TitleViewModel();
        while (!(window is EndBase)) { window = window.Execute(); }
        Console.Write("\x1b[1;1H");
    }
}