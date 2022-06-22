/// Mathis Broquet
/// ETML Lausanne
/// 25.05.2022
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;

namespace P_Jass
{
    class Program
    {
        //Properties
        private static List<string> _mainMenu = new List<string> { "Se connecter", "Créer un compte", "Quitter"};
        private static Menu _menuMain = new Menu(_mainMenu, MenuHorizontal.center, ConsoleColor.Green, 5);

        private static List<string> _nameMenu = new List<string> { "Jouer", "Paramètres", "Comment jouer", "Aide", "Stats", "Logout", "Quitter" };
        private static Menu _menuName = new Menu(_nameMenu, MenuHorizontal.center , ConsoleColor.Green, 2 );

        private static List<string> _parameterMenu = new List<string> { "Pixel profile", "Nom de joueur",  "Volume", "Selection des cartes", "Retour" };
        private static Menu _menuParameter = new Menu(_parameterMenu, MenuHorizontal.center, ConsoleColor.Green, 1);

        private static Username _username;
        private static Title _login = new Title(new List<string> { @"__/\\\___________________/\\\\\__________/\\\\\\\\\\\\__/\\\\\\\\\\\__/\\\\\_____/\\\_        ", @" _\/\\\_________________/\\\///\\\______/\\\//////////__\/////\\\///__\/\\\\\\___\/\\\_       ", @"  _\/\\\_______________/\\\/__\///\\\___/\\\_________________\/\\\_____\/\\\/\\\__\/\\\_      ", @"   _\/\\\______________/\\\______\//\\\_\/\\\____/\\\\\\\_____\/\\\_____\/\\\//\\\_\/\\\_     ", @"    _\/\\\_____________\/\\\_______\/\\\_\/\\\___\/////\\\_____\/\\\_____\/\\\\//\\\\/\\\_    ", @"     _\/\\\_____________\//\\\______/\\\__\/\\\_______\/\\\_____\/\\\_____\/\\\_\//\\\/\\\_   ", @"      _\/\\\______________\///\\\__/\\\____\/\\\_______\/\\\_____\/\\\_____\/\\\__\//\\\\\\_  ", @"       _\/\\\\\\\\\\\\\\\____\///\\\\\/_____\//\\\\\\\\\\\\/___/\\\\\\\\\\\_\/\\\___\//\\\\\_ ", @"        _\///////////////_______\/////________\////////////____\///////////__\///_____\/////__" });
        private static Title _cardsOrder = new Title(new List<string> { @"________/\\\\\\\\\_____/\\\\\\\\\_______/\\\\\\\\\______/\\\\\\\\\\\\________/\\\\\\\\\\\___________________/\\\\\_________/\\\\\\\\\______/\\\\\\\\\\\\_____/\\\\\\\\\\\\\\\____/\\\\\\\\\_____        ", @" _____/\\\////////____/\\\\\\\\\\\\\___/\\\///////\\\___\/\\\////////\\\____/\\\/////////\\\_______________/\\\///\\\_____/\\\///////\\\___\/\\\////////\\\__\/\\\///////////___/\\\///////\\\___       ", @"  ___/\\\/____________/\\\/////////\\\_\/\\\_____\/\\\___\/\\\______\//\\\__\//\\\______\///______________/\\\/__\///\\\__\/\\\_____\/\\\___\/\\\______\//\\\_\/\\\_____________\/\\\_____\/\\\___      ", @"   __/\\\_____________\/\\\_______\/\\\_\/\\\\\\\\\\\/____\/\\\_______\/\\\___\////\\\____________________/\\\______\//\\\_\/\\\\\\\\\\\/____\/\\\_______\/\\\_\/\\\\\\\\\\\_____\/\\\\\\\\\\\/____     ", @"    _\/\\\_____________\/\\\\\\\\\\\\\\\_\/\\\//////\\\____\/\\\_______\/\\\______\////\\\________________\/\\\_______\/\\\_\/\\\//////\\\____\/\\\_______\/\\\_\/\\\///////______\/\\\//////\\\____    ", @"     _\//\\\____________\/\\\/////////\\\_\/\\\____\//\\\___\/\\\_______\/\\\_________\////\\\_____________\//\\\______/\\\__\/\\\____\//\\\___\/\\\_______\/\\\_\/\\\_____________\/\\\____\//\\\___   ", @"      __\///\\\__________\/\\\_______\/\\\_\/\\\_____\//\\\__\/\\\_______/\\\___/\\\______\//\\\_____________\///\\\__/\\\____\/\\\_____\//\\\__\/\\\_______/\\\__\/\\\_____________\/\\\_____\//\\\__  ", @"       ____\////\\\\\\\\\_\/\\\_______\/\\\_\/\\\______\//\\\_\/\\\\\\\\\\\\/___\///\\\\\\\\\\\/________________\///\\\\\/_____\/\\\______\//\\\_\/\\\\\\\\\\\\/___\/\\\\\\\\\\\\\\\_\/\\\______\//\\\_ ", @"        _______\/////////__\///________\///__\///________\///__\////////////_______\///////////____________________\/////_______\///________\///__\////////////_____\///////////////__\///________\///__" });

        private static List<string> _cardMenu = new List<string> { "╔─╗ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠\n│♠│ │R│ │D│ │V│ │X│ │9│ │8│ │7│ │6│\n╚─╝ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠", "♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ╔─╗\n│6│ │7│ │8│ │9│ │X│ │V│ │D│ │R│ │♠│\n♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ♠─♠ ╚─╝", "╔─╗ ╔─╗ ╔─╗ ╔─╗ ♠─♠ ♥─♥ ♣─♣ ♦─♦ ♠─♠\n│♠│ │♥│ │♣│ │♦│ │R│ │R│ │R│ │R│ │D│\n╚─╝ ╚─╝ ╚─╝ ╚─╝ ♠─♠ ♥─♥ ♣─♣ ♦─♦ ♠─♠" };
        private static Menu _menuCard = new Menu(_cardMenu, MenuHorizontal.center, ConsoleColor.Green, 3);

        /// <summary>
        /// Main method
        /// </summary>
        private static void Main()
        {
            /*Type type = new Type("K", "4");
            Sign sign = new Sign('♥', Color.Red);
            Card card0 = new Card(type, sign, true);
            List<Card> cards = new List<Card>() { card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0, card0};
            card0.Cut(cards);*/

            /*Slide presentation = new Slide("Aide", "Dans ce jeu les touches sont les suivantes: ↕ pour monter\n ou\n decendre dans les menus\n1234567890");
            Slide presentation2 = new Slide("123456", "Bonsoir", "DAMMM LES GENS");
            Presentation presentation1 = new Presentation(new List<Slide> { presentation, presentation2 });
            presentation1.Start();*/
            System.Console.SetWindowSize(190, 30);
            Custom();
            SecondaryMain();
        }

        /// <summary>
        /// Custom all menu string
        /// </summary>
        private static void Custom()
        {
            _menuMain.CustomText('╔', '╗', '╚', '╝');
            _menuParameter.CustomText('╔', '╗', '╚', '╝');
            _menuName.CustomText('╔', '╗', '╚', '╝');
        }

        /// <summary>
        /// Is the secondary main to fix bug with the custom wenn we logout
        /// </summary>
        private static void SecondaryMain()
        {
            _login.Display();
            _login.Animate();
            _menuMain.Display(false);
            _username = new Username();
            SecondaryMainSelection();
            DispplayAndAnimateMenu();

        }

        private static void SecondaryMainSelection()
        {
            switch (_menuMain.Slection())
            {
                case "Se connecter":
                    _username.Display();
                    _username.ChangeName();
                    break;
                case "Créer un compte":
                    _username.Display();
                    _username.ChangeName();
                    break;
                case "Quitter":
                    Exit();
                    break;
                default:
                    break;
            }
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
            //Reset properties
            System.Console.Clear();
            _menuParameter.Display(true);

            switch (_menuParameter.Slection())
            {
                case "Pixel profile":
                    Parameter();
                    break;
                case "Nom de joueur":
                    _username.Display();
                    _username.ChangeName();
                    Parameter();
                    break;
                case "Volume":
                    Parameter();
                    break;
                case "Selection des cartes":
                    _cardsOrder.Display();
                    _cardsOrder.Animate();
                    _menuCard.Display(true);
                    _menuCard.Slection("◄=", true);
                    break;
                case "Retour":
                    DispplayAndAnimateMenu();
                    break;
                default:
                    Default();
                    break;
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
            Slide presentation = new Slide("Aide", "Dans ce jeu les touches sont les suivantes: ↕ pour monter\n ou\n decendre dans les menus\n1234567890");
            Slide presentation2 = new Slide("123456", "Bonsoir", "DAMMM LES GENS");
            Presentation presentation1 = new Presentation(new List<Slide> { presentation, presentation2 });
            presentation1.Start();
            DispplayAndAnimateMenu();
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
            menuDefault.Display(true);
            menuDefault.Slection();
            DispplayAndAnimateMenu();
        }

        /// <summary>
        /// Generate the graphic and the selection system
        /// </summary>
        private static void DispplayAndAnimateMenu()
        {
            System.Console.Clear();
            _menuName.Display(true);
            switch (_menuName.Slection())
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
                case "Logout":
                    SecondaryMain();
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
