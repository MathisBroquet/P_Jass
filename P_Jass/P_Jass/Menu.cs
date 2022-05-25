using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace P_Jass
{
    /// <summary>
    /// Initialize Menu
    /// </summary>
    public class Menu
    {
        //Properties
        private List<string> _menuNames;
        private MenuHorizontal _menuStyle;
        private ConsoleColor _color;
        private byte _menuMarginBetween;
        private byte _nbrLines;
        private byte _currentWidth;
        private string[] _lines;
        private byte _currentLine;
        private string custom;
        private byte counter;
        private byte before;
        private Dictionary<string, Tuple<int, int>> _menuCoords;
        private  Random _random;

        /// <summary>
        /// Constructor of the Menu
        /// </summary>
        /// <param name="menuNames">List of string of all menu</param>
        /// <param name="menuStyle">The horizontal parameter</param>
        /// <param name="color">The color of the menu</param>
        /// <param name="menuMarginBetween">The margin between each menu</param>
        public Menu(List<string> menuNames, MenuHorizontal menuStyle, ConsoleColor color, byte menuMarginBetween = 0)
        {
            _menuNames = menuNames;
            _menuStyle = menuStyle;
            _color = color;
            _menuMarginBetween = menuMarginBetween;
            _nbrLines = 0;
            _currentWidth = 0;
            _random = new Random();
            _menuCoords = new Dictionary<string, Tuple<int, int>>();
            foreach (string item in _menuNames)
            {
                for (int i = 0; i < item.Split("\n").Length; i++)
                {
                    _nbrLines++;
                }
                _nbrLines -= 1;
            }       //Count the numbers of \n
        }

        /// <summary>
        /// Display the menu
        /// </summary>
        public void Display()
        {
            //Properties
            _currentLine = Convert.ToByte((Console.WindowHeight - _menuNames.Count - _nbrLines - (_menuNames.Count - 2) * _menuMarginBetween)/2);
            Console.ForegroundColor = _color;

            //Write the menu
            foreach (string item in _menuNames)
            {
                _lines = item.Split('\n');
                //Write the text line per line
                for (int i = 0; i < item.Split('\n').Length; i++)
                {
                    //Set the axe Y position of the cursor
                    switch (_menuStyle)
                    {
                        case MenuHorizontal.left:
                            _currentWidth = 0;
                            break;
                        case MenuHorizontal.center:
                            _currentWidth = Convert.ToByte(Console.WindowWidth / 2 - _lines[0].Length / 2);
                            break;
                        case MenuHorizontal.right:
                            _currentWidth = Convert.ToByte(Console.WindowWidth - _lines[0].Length);
                            break;
                        default:
                            _currentWidth = Convert.ToByte(Console.WindowWidth / 2 - _lines[0].Length / 2);
                            break;
                    }

                    Console.SetCursorPosition(_currentWidth, _currentLine + i);
                    if (_lines[i].Contains(item.Split("\n")[1].Substring(1, item.Split("\n")[1].Length - 2)))
                    {
                        Tuple<int, int> tuple = new Tuple<int, int>(_currentWidth, _currentLine + i);
                        _menuCoords.Add(item.Split("\n")[1].Substring(1, item.Split("\n")[1].Length - 2), tuple);
                    }
                    Console.WriteLine(_lines[i]);

                }
                _currentLine++;
                // Add the margin between
                for (int y = 0; y < _menuMarginBetween; y++)
                {
                    _currentLine++;
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Customize the menu
        /// </summary>
        /// <param name="c1">The top left corner</param>
        /// <param name="c2">The top right corner</param>
        /// <param name="c3">The bottom left corner</param>
        /// <param name="c4">The bottom right corner</param>
        /// <param name="vertical">The vertical character (between c1 & c3 && c2 & c4)</param>
        /// <param name="horizontal">The horizontal character (between c1 & c2 && c3 & c4)</param>
        public void CustomText(char c1 = '┌', char c2 = '┐', char c3 = '└', char c4 = '┘', char vertical = '│', char horizontal = '─')
        {
            // Write the custom
            for (int i = 0; i < _menuNames.Count; i++)
            {
                custom = "";
                //Write top custom
                custom += c1;
                for (int x = 0; x < _menuNames[i].Length; x++)
                {
                    custom += horizontal;
                }
                custom += c2 + "\n";

                //Write middle custom
                custom += vertical + _menuNames[i] + vertical + "\n";

                //Write bottom custom
                custom += c3;
                for (int y = 0; y < _menuNames[i].Length; y++)
                {
                    custom += horizontal;
                }
                custom += c4;

                //Adjust the new properties to the custom
                _menuNames[i] = custom;
                _nbrLines += 2;
            }
            _nbrLines -= 2;
            _menuMarginBetween += 2;
        }

        public void Slection(string selector = "◄═")
        {
            counter = 0;
            before = 0;
            ConsoleKey key;
            Console.CursorVisible = false;
            do
            {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.DownArrow)
                {
                    //Set counter properties
                    counter++;
                    if (counter > _menuNames.Count - 1)
                    {
                        counter = 0;
                    }

                    //Replace the selector at the next element
                    DeleteSelector(before);
                    PrintSelector(counter, selector);

                    //Set the new previous before
                    before = counter;
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    //Set counter properties
                    counter--;
                    if (counter == 255)
                    {
                        counter =  (byte)(_menuNames.Count - 1);
                    }

                    //Replace the selector at the previous element
                    DeleteSelector(before);
                    PrintSelector(counter, selector);

                    //Set the new previous before
                    before = counter;
                }
            } while (key != ConsoleKey.Enter);
            AnimationSelect(1);
        }

        /// <summary>
        /// Delete the previous selector
        /// </summary>
        /// <param name="before">the previous selector</param>
        private void DeleteSelector(byte before)
        {
            Console.SetCursorPosition(_menuCoords[_menuNames[before].Split("\n")[1].Substring(1, _menuNames[before].Split("\n")[1].Length - 2)].Item1 + _menuNames[before].Split("\n")[1].Substring(1, _menuNames[before].Split("\n")[1].Length - 2).Length + 2, _menuCoords[_menuNames[before].Split("\n")[1].Substring(1, _menuNames[before].Split("\n")[1].Length - 2)].Item2);
            Console.Write("  ");
        }

        /// <summary>
        /// Add the next selector
        /// </summary>
        /// <param name="counter">The actuel position of the selector</param>
        private void PrintSelector(byte counter, string selector)
        {
            Console.SetCursorPosition(_menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2).Length + 2, _menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item2);
            Console.Write(selector);
        }

        private void AnimationSelect(byte slowly)
        {
            for (int i = 0; i < _menuNames[counter].Split("\n")[1].Length; i++)
            {
                Console.SetCursorPosition(_menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2).Length + 2 - (i-1), _menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item2);
                Console.Write("  ");

                Console.SetCursorPosition(_menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2).Length + 2  - i, _menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item2);
                Console.Write("◄═");

                Thread.Sleep(slowly);
            }

            Console.SetCursorPosition(_menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2).Length + 2 - _menuNames[counter].Split("\n")[1].Length, _menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item2);
            Console.Write("╠─ ");

            Thread.Sleep(slowly);

            Console.SetCursorPosition(_menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2).Length + 2 - _menuNames[counter].Split("\n")[1].Length, _menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item2);
            Console.Write("║ ");

            Thread.Sleep(slowly);

            Console.SetCursorPosition(_menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2).Length + 2 - _menuNames[counter].Split("\n")[1].Length, _menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item2 - 1);
            Console.Write("╔");

            Console.SetCursorPosition(_menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2).Length + 2 - _menuNames[counter].Split("\n")[1].Length, _menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item2 + 1);
            Console.Write("╚");

            Thread.Sleep(slowly);

            for (int i = _menuNames[counter].Split("\n")[1].Length - 1; i > 1; i--)
            {
                Console.SetCursorPosition(_menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2).Length + 2 - (i - 1), _menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item2 +  1);
                Console.Write(" ");

                Console.SetCursorPosition(_menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2).Length + 2 - i, _menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item2 + 1);
                Console.Write("═");

                Console.SetCursorPosition(_menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2).Length + 2 - (i - 1), _menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item2 - 1);
                Console.Write(" ");

                Console.SetCursorPosition(_menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2).Length + 2 - i, _menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item2 - 1);
                Console.Write("═");

                Thread.Sleep(slowly);
            }

            Console.SetCursorPosition(_menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2).Length + 1, _menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item2 - 1);
            Console.Write("╗");

            Console.SetCursorPosition(_menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2).Length + 1, _menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item2 + 1);
            Console.Write("╝");

            Thread.Sleep(slowly);

            Console.SetCursorPosition(_menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2).Length + 1, _menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item2);
            Console.Write("║");

            for (int i = 100; i > 0; i++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Console.SetCursorPosition(_random.Next(Console.WindowWidth / i) + Console.WindowWidth/2, _random.Next(Console.WindowHeight / i) + Console.WindowHeight / 2);
                    Console.Write(RandomSign());
                }
            }
        }

        private char RandomSign()
        {
            switch (_random.Next(1, 5))
            {
                case 1:
                    return '♥';
                    break;
                case 2:
                    return '♦';
                    break;
                case 3:
                    return '♣';
                    break;
                case 4:
                    return '♠';
                default:
                    return ' ';
                    break;
            }

        }
    }
}
