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
        public Title(List<string> menuUsername)
        {
            _menuUsername = menuUsername;

            _windowsHeight = System.Console.WindowHeight - _menuUsername.Count;
            _height = _menuUsername.Count;
        }

        /// <summary>
        /// Display the title
        /// </summary>
        public void Display()
        {
            System.Console.Clear();
            System.Console.SetWindowSize(_menuUsername[0].Length + 1, 40);
            System.Console.BufferWidth = _menuUsername[0].Length + 1;
            System.Console.BufferHeight = 40;
            for (int i = 0; i < _menuUsername.Count; i++)
            {
                System.Console.SetCursorPosition(1, i);
                System.Console.WriteLine(_menuUsername[i]);
            }
        }

        /// <summary>
        /// Animate the Title
        /// </summary>
        public void Animate()
        {
            System.Console.CursorVisible = false;
            for (int i = 0; i < _menuUsername[0].Length; i++)
            {
                for (int x = 0; x < _menuUsername.Count; x++)
                {
                    if (_menuUsername[x][i] == '/' || _menuUsername[x][i] == '\\')
                    {
                        System.Console.SetCursorPosition(i + 1, x);
                        System.Console.WriteLine('_');
                    }
                    if (x % _menuUsername.Count == 0)
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
                    System.Console.SetCursorPosition(i + 1, x);
                    if (_menuUsername[x][i] == '_')
                    {
                        System.Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        System.Console.ForegroundColor = ConsoleColor.Green;
                    }
                    System.Console.WriteLine(_menuUsername[x][i]);
                    if (x % _menuUsername.Count == 0)
                    {
                        Thread.Sleep(1);
                    }
                }
            }
            System.Console.ForegroundColor = ConsoleColor.Gray;
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
