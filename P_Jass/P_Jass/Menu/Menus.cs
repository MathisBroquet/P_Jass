/// Mathis Broquet
/// ETML Lausanne
/// 25.05.2022
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
        private string _custom;
        private byte _counter;
        private byte _before;
        private Dictionary<string, Tuple<int, int>> _menuCoords;
        private Random _random;
        private Tuple<int, int> _tuple;
        private bool _isCustom;

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
            _lines = null;
            _currentLine = 0;
            _custom = "";
            _before = 0;
            _tuple = null;
            _random = new Random();
            _menuCoords = new Dictionary<string, Tuple<int, int>>();
            _isCustom = false;
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
            Console.Clear();
            Console.SetWindowSize(240, 63);
            _currentLine = Convert.ToByte((Console.WindowHeight - (_menuNames.Count - 1) - _nbrLines - (_menuNames.Count - 3) * _menuMarginBetween)/2);
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
                    if(_lines[i]  == item)
                    {
                        _tuple = new Tuple<int, int>(_currentWidth, _currentLine + i);
                        _menuCoords.TryAdd(item, _tuple);
                    }
                    else if (_lines[i].Contains(item.Split("\n")[1].Substring(1, item.Split("\n")[1].Length - 2)))
                    {
                        _tuple = new Tuple<int, int>(_currentWidth, _currentLine + i);
                        _menuCoords.TryAdd(item.Split("\n")[1].Substring(1, item.Split("\n")[1].Length - 2), _tuple);
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
            _isCustom = true;
            // Write the custom
            for (int i = 0; i < _menuNames.Count; i++)
            {
                _custom = "";
                //Write top custom
                _custom += c1;
                for (int x = 0; x < _menuNames[i].Length; x++)
                {
                    _custom += horizontal;
                }
                _custom += c2 + "\n";

                //Write middle custom
                _custom += vertical + _menuNames[i] + vertical + "\n";

                //Write bottom custom
                _custom += c3;
                for (int y = 0; y < _menuNames[i].Length; y++)
                {
                    _custom += horizontal;
                }
                _custom += c4;

                //Adjust the new properties to the custom
                _menuNames[i] = _custom;
                _nbrLines += 2;
            }
            _nbrLines -= 2;
            _menuMarginBetween += 2;
        }

        public string Slection(string selector = "◄═")
        {
            _counter = 0;
            _before = 0;
            ConsoleKey key;
            Console.CursorVisible = false;
            PrintSelector(_counter, selector);
            do
            {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.DownArrow)
                {
                    //Set counter properties
                    _counter++;
                    if (_counter > _menuNames.Count - 1)
                    {
                        _counter = 0;
                    }

                    //Replace the selector at the next element
                    DeleteSelector(_before);
                    PrintSelector(_counter, selector);

                    //Set the new previous before
                    _before = _counter;
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    //Set counter properties
                    _counter--;
                    if (_counter == 255)
                    {
                        _counter =  (byte)(_menuNames.Count - 1);
                    }

                    //Replace the selector at the previous element
                    DeleteSelector(_before);
                    PrintSelector(_counter, selector);

                    //Set the new previous before
                    _before = _counter;
                }
            } while (key != ConsoleKey.Enter);
            if (_isCustom)
            {
                AnimationSelect(1);
                return _menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2);
            }
            else
            {
                return _menuNames[_counter];
            }
        }

        /// <summary>
        /// Delete the previous selector
        /// </summary>
        /// <param name="before">the previous selector</param>
        private void DeleteSelector(byte before)
        {
            if (_isCustom)
            {
                Console.SetCursorPosition(_menuCoords[_menuNames[before].Split("\n")[1].Substring(1, _menuNames[before].Split("\n")[1].Length - 2)].Item1 + _menuNames[before].Split("\n")[1].Substring(1, _menuNames[before].Split("\n")[1].Length - 2).Length + 2, _menuCoords[_menuNames[before].Split("\n")[1].Substring(1, _menuNames[before].Split("\n")[1].Length - 2)].Item2);
            }
            else
            {
                Console.SetCursorPosition(_menuCoords[_menuNames[before]].Item1 + _menuNames[before].Length + 2, _menuCoords[_menuNames[before]].Item2);
            }
            Console.Write("  ");
        }

        /// <summary>
        /// Add the next selector
        /// </summary>
        /// <param name="counter">The actuel position of the selector</param>
        private void PrintSelector(byte counter, string selector)
        {
            if (_isCustom)
            {
                Console.SetCursorPosition(_menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2).Length + 2, _menuCoords[_menuNames[counter].Split("\n")[1].Substring(1, _menuNames[counter].Split("\n")[1].Length - 2)].Item2);
            }
            else
            {
                Console.SetCursorPosition(_menuCoords[_menuNames[counter]].Item1 + _menuNames[counter].Length + 2, _menuCoords[_menuNames[counter]].Item2);
            }
            Console.Write(selector);
        }

        private void AnimationSelect(byte slowly)
        {
            #region Animation of the selector
            for (int i = 0; i < _menuNames[_counter].Split("\n")[1].Length; i++)
            {
                Console.SetCursorPosition(_menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2).Length + 2 - (i-1), _menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item2);
                Console.Write("  ");

                Console.SetCursorPosition(_menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2).Length + 2  - i, _menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item2);
                Console.Write("◄═");

                Thread.Sleep(slowly);
            }

            Console.SetCursorPosition(_menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2).Length + 2 - _menuNames[_counter].Split("\n")[1].Length, _menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item2);
            Console.Write("╠─ ");

            Thread.Sleep(slowly);

            Console.SetCursorPosition(_menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2).Length + 2 - _menuNames[_counter].Split("\n")[1].Length, _menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item2);
            Console.Write("║ ");

            Thread.Sleep(slowly);

            Console.SetCursorPosition(_menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2).Length + 2 - _menuNames[_counter].Split("\n")[1].Length, _menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item2 - 1);
            Console.Write("╔");

            Console.SetCursorPosition(_menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2).Length + 2 - _menuNames[_counter].Split("\n")[1].Length, _menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item2 + 1);
            Console.Write("╚");

            Thread.Sleep(slowly);
            #endregion

            #region Animation of the horizontal lines
            for (int i = _menuNames[_counter].Split("\n")[1].Length - 1; i > 1; i--)
            {
                Console.SetCursorPosition(_menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2).Length + 2 - (i - 1), _menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item2 +  1);
                Console.Write(" ");

                Console.SetCursorPosition(_menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2).Length + 2 - i, _menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item2 + 1);
                Console.Write("═");

                Console.SetCursorPosition(_menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2).Length + 2 - (i - 1), _menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item2 - 1);
                Console.Write(" ");

                Console.SetCursorPosition(_menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2).Length + 2 - i, _menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item2 - 1);
                Console.Write("═");

                Thread.Sleep(slowly);
            }
            #endregion

            #region Animation of the end of the box
            Console.SetCursorPosition(_menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2).Length + 1, _menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item2 - 1);
            Console.Write("╗");

            Console.SetCursorPosition(_menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2).Length + 1, _menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item2 + 1);
            Console.Write("╝");

            Thread.Sleep(slowly);

            Console.SetCursorPosition(_menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item1 + _menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2).Length + 1, _menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item2);
            Console.Write("║");
            #endregion

            #region Animation Load
            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < _menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2).Length / 2; x++)
                {
                    Console.SetCursorPosition(x *  2 + _menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item1 + 1, _menuCoords[_menuNames[_counter].Split("\n")[1].Substring(1, _menuNames[_counter].Split("\n")[1].Length - 2)].Item2);
                    if(i % 2 == 0)
                    {
                        Console.Write(" " + RandomSign());
                        Thread.Sleep(slowly * 25);
                    }
                    else
                    {
                        Console.WriteLine("  ");
                        Thread.Sleep(slowly * 50);

                    }
                    Thread.Sleep(slowly * 50);
                }
            }
            #endregion
        }

        private char RandomSign()
        {
            switch (_random.Next(1, 5))
            {
                case 1:
                    return '♥';
                case 2:
                    return '♦';
                case 3:
                    return '♣';
                case 4:
                    return '♠';
                default:
                    return ' ';
            }

        }
    }
}
