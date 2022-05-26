using System;
using System.Collections.Generic;
using System.Net;

namespace P_Jass
{
    class Program
    {
        private static List<string> menuNames = new List<string> { "jouer", "Paramètres", "Comment jouer", "Aide", "Stats", "Quitter" };
        private static Menu menu = new Menu(menuNames, MenuHorizontal.center , ConsoleColor.DarkMagenta, 2);
        static void Main()
        {
            menu.CustomText('╔', '╗', '╚', '╝');
            menu.Display();
            switch (menu.Slection())
            {
                case "jouer":
                    Game();
                    break;
                case "Paramètres":
                    Parameter();
                    break;
                case "Comment jouer":
                    HowToPlay();
                    break;
                case "Aide":
                    Help();
                    break;
                case "Stats":
                    Stats();
                    break;
                case "Quitter":
                   Default();
                    break;
                default:
                    Default();
                    break;
            }
        }
        public static void Game()
        {

        }

        public static void Parameter()
        {

        }

        public static void HowToPlay()
        {

        }

        public static void Help()
        {

        }

        public static void Stats()
        {

        }

        public static void Exit()
        {
            Environment.Exit(0);
        }

        public static void Default()
        {
            Console.Clear();
            Console.WriteLine("Une erreur est survenue");
            List<string> defaultError = new List<string> {"Revenir  au menu" };
            Menu menuDefault = new Menu(defaultError, MenuHorizontal.center, ConsoleColor.Green);
            menuDefault.CustomText();
            menuDefault.Display();
            while(menuDefault.Slection() == "Revenir  au menu")
            {
                Main();
            }
        }
    }
}
