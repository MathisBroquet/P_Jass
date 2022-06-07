using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace P_Jass
{
    class Title
    {
        //Properties
        private List<string> _menuUsername;
        private int _windowsHeight;
        private int _height;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="menuUsername">List of all lines for the menu title (https://patorjk.com/software/taag/#p=display&f=Slant%20Relief&t=Type%20Something%20)</param>
        public Title(List<string> menuUsername = null)
        {
            if (menuUsername == null)
            {
                _menuUsername = new List<string> { @"__/\\\________/\\\_____/\\\\\\\\\\\____/\\\\\\\\\\\\\\\____/\\\\\\\\\______/\\\\\_____/\\\_____/\\\\\\\\\_____/\\\\____________/\\\\__/\\\\\\\\\\\\\\\_        ", @" _\/\\\_______\/\\\___/\\\/////////\\\_\/\\\///////////___/\\\///////\\\___\/\\\\\\___\/\\\___/\\\\\\\\\\\\\__\/\\\\\\________/\\\\\\_\/\\\///////////__       ", @"  _\/\\\_______\/\\\__\//\\\______\///__\/\\\_____________\/\\\_____\/\\\___\/\\\/\\\__\/\\\__/\\\/////////\\\_\/\\\//\\\____/\\\//\\\_\/\\\_____________      ", @"   _\/\\\_______\/\\\___\////\\\_________\/\\\\\\\\\\\_____\/\\\\\\\\\\\/____\/\\\//\\\_\/\\\_\/\\\_______\/\\\_\/\\\\///\\\/\\\/_\/\\\_\/\\\\\\\\\\\_____     ", @"    _\/\\\_______\/\\\______\////\\\______\/\\\///////______\/\\\//////\\\____\/\\\\//\\\\/\\\_\/\\\\\\\\\\\\\\\_\/\\\__\///\\\/___\/\\\_\/\\\///////______    ", @"     _\/\\\_______\/\\\_________\////\\\___\/\\\_____________\/\\\____\//\\\___\/\\\_\//\\\/\\\_\/\\\/////////\\\_\/\\\____\///_____\/\\\_\/\\\_____________   ", @"      _\//\\\______/\\\___/\\\______\//\\\__\/\\\_____________\/\\\_____\//\\\__\/\\\__\//\\\\\\_\/\\\_______\/\\\_\/\\\_____________\/\\\_\/\\\_____________  ", @"       __\///\\\\\\\\\/___\///\\\\\\\\\\\/___\/\\\\\\\\\\\\\\\_\/\\\______\//\\\_\/\\\___\//\\\\\_\/\\\_______\/\\\_\/\\\_____________\/\\\_\/\\\\\\\\\\\\\\\_ ", @"        ____\/////////_______\///////////_____\///////////////__\///________\///__\///_____\/////__\///________\///__\///______________\///__\///////////////__" };
            }
            else
            {
                _menuUsername = menuUsername;
            }

            _windowsHeight = Console.WindowHeight - _menuUsername.Count;
            _height = _menuUsername.Count;
        }

        /// <summary>
        /// Display the title
        /// </summary>
        public void Display()
        {
            Console.Clear();
            Console.SetWindowSize(_menuUsername[0].Length + 1, 40);
            Console.BufferWidth = _menuUsername[0].Length + 1;
            Console.BufferHeight = 40;
            for (int i = 0; i < _menuUsername.Count; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.WriteLine(_menuUsername[i]);
            }
        }

        /// <summary>
        /// Animate the Title
        /// </summary>
        public void Animate()
        {
            Console.CursorVisible = false;
            for (int i = 0; i < _menuUsername[0].Length; i++)
            {
                for (int x = 0; x < _menuUsername.Count; x++)
                {
                    if (_menuUsername[x][i] == '/' || _menuUsername[x][i] == '\\')
                    {
                        Console.SetCursorPosition(i + 1, x);
                        Console.WriteLine('_');
                    }
                    if (x % 49 == 1)
                    {
                        Thread.Sleep(1);
                    }
                }
            }
            Thread.Sleep(500);
            for (int i = _menuUsername[0].Length - 1; i > -1; i--)
            {
                for (int x = _menuUsername.Count - 1; x > -1; x--)
                {
                    Console.SetCursorPosition(i + 1, x);
                    if (_menuUsername[x][i] == '_')
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine(_menuUsername[x][i]);
                    if (x % 49 == 1)
                    {
                        Thread.Sleep(1);
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Getter
        /// </summary>
        public int WindowsHeight
        {
            get { return _windowsHeight; }
        }

        /// <summary>
        /// Getter
        /// </summary>
        public int Height
        {
            get { return _height; }
        }
    }
}
