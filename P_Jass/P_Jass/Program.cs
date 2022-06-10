/// Mathis Broquet
/// ETML Lausanne
/// 25.05.2022
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace P_Jass
{
    class Program
    {
        //Properties
        private static List<string> menuNames = new List<string> { "Jouer", "Paramètres", "Comment jouer", "Aide", "Stats", "Quitter" };
        private static Menu menu = new Menu(menuNames, MenuHorizontal.center , ConsoleColor.Green, 2 );
        private static List<string> parametersNames = new List<string> { "Pixel profile", "Nom de joueur",  "Volume", "Selection des cartes", "Retour" };
        private static Menu parameters = new Menu(parametersNames, MenuHorizontal.center, ConsoleColor.Green, 1);
        private static Username test = new Username("Damien Loup");

        /// <summary>
        /// Main method
        /// </summary>
        private static void Main()
        {
            parameters.CustomText('╔', '╗', '╚', '╝');
            menu.CustomText('╔', '╗', '╚', '╝');
            DispplayAndAnimateMenu();
        }

        /// <summary>
        /// start the game
        /// </summary>
        private static void Game()
        {

        }

        /// <summary>
        /// All about the parameter
        /// </summary>
        private static void Parameter()
        {
            parameters.Display();
            switch (parameters.Slection())
            {
                case "Pixel profile":
                    break;
                case "Nom de joueur":
                    test.Display();
                    test.ChangeName();
                    Parameter();
                    break;
                case "Volume":
                    break;
                case "Selection des cartes":
                    break;
                case "Retour":
                    DispplayAndAnimateMenu();
                    break;
                default:
                    Default();
                    break;

/*╔─╗ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠
  │♠│ │R│ │D│ │V│ │X│ │9│ │8│ │7│ │6│
  ╚─╝ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠
  
  ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ╔─╗
  │6│ │7│ │8│ │9│ │X│ │V│ │D│ │R│ │♠│
  ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ╚─╝
  
  ╔─╗ ╔─╗ ╔─╗ ╔─╗ ♠─♠ ♥─♥ ♣─♣ ♦─♦ ♠─♠
  │♠│ │♥│ │♣│ │♦│ │R│ │R│ │R│ │R│ │D│
  ╚─╝ ╚─╝ ╚─╝ ╚─╝ ♠─♠ ♥─♥ ♣─♣ ♦─♦ ♠─♠*/
            }
        }

        /// <summary>
        /// All about how to play
        /// </summary>
        private static void HowToPlay()
        {

        }

        /// <summary>
        /// All about the help
        /// </summary>
        private static void Help()
        {

        }

        /// <summary>
        /// All about the stats of the player
        /// </summary>
        private static void Stats()
        {

        }

        /// <summary>
        /// Exit the game
        /// </summary>
        private static void Exit()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// If an error occured during the menu selecting
        /// </summary>
        private static void Default()
        {
            System.Console.Clear();
            System.Console.WriteLine("Une erreur est survenue");
            List<string> defaultError = new List<string> {"Revenir  au menu" };
            Menu menuDefault = new Menu(defaultError, MenuHorizontal.left, ConsoleColor.Green);
            menuDefault.CustomText();
            menuDefault.Display();
            menuDefault.Slection();
            DispplayAndAnimateMenu();
        }

        /// <summary>
        /// Generate the graphic and the selection system
        /// </summary>
        private static void DispplayAndAnimateMenu()
        {
            menu.Display();
            switch (menu.Slection())
            {
                case "Jouer":
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
                    Exit();
                    break;
                default:
                    Default();
                    break;
            }
        }
    }
}
