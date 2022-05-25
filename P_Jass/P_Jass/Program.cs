using System;
using System.Collections.Generic;
using System.Net;

namespace P_Jass
{
    class Program
    {
        static void Main()
        {
            List<string> menuNames = new List<string> { "jouer", "Paramètres", "Comment jouer", "Aide", "Stats", "Quitter" };
            Console.SetWindowSize(230, 60);
            Menu menu = new Menu(menuNames, MenuHorizontal.center, ConsoleColor.DarkMagenta, 2);
            menu.CustomText('╔', '╗', '╚', '╝');
            menu.Display();
            menu.Slection();
            Console.ReadLine();
        }
    }
}
