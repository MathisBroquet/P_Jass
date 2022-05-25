using System;
using System.Collections.Generic;
using System.Text;

namespace P_Jass
{
    /// <summary>
    /// Initialize Menu
    /// </summary>
    public class Menu
    {
        //Properties
        private List<string> _menuNames;
        private MenuStyle _menuStyle;
        private ConsoleColor _color;
        private byte _menuMarginBetween;
        private byte _nbrLines;
        private byte _currentWidth;
        private string[] _lines;
        private byte _currentLine;
        private string custom;
        private Dictionary<string, Tuple<int, int>> _menuCoords;

        /// <summary>
        /// Constructor of the Menu
        /// </summary>
        /// <param name="menuNames">List of string of all menu</param>
        /// <param name="menuStyle">The horizontal parameter</param>
        /// <param name="color">The color of the menu</param>
        /// <param name="menuMarginBetween">The margin between each menu</param>
        public Menu(List<string> menuNames, MenuStyle menuStyle, ConsoleColor color, byte menuMarginBetween = 0)
        {
            _menuNames = menuNames;
            _menuStyle = menuStyle;
            _color = color;
            _menuMarginBetween = menuMarginBetween;
            _nbrLines = 0;
            _currentWidth = 0;
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
                        case MenuStyle.left:
                            _currentWidth = 0;
                            break;
                        case MenuStyle.center:
                            _currentWidth = Convert.ToByte(Console.WindowWidth / 2 - _lines[0].Length / 2);
                            break;
                        case MenuStyle.right:
                            _currentWidth = Convert.ToByte(Console.WindowWidth - _lines[0].Length);
                            break;
                        default:
                            _currentWidth = Convert.ToByte(Console.WindowWidth / 2 - _lines[0].Length / 2);
                            break;
                    }

                    Console.SetCursorPosition(_currentWidth, _currentLine + i);
                    /*if (_lines[i].Contains(item.Split("\n")[1]))
                    {
                        Tuple<int, int> tuple = new Tuple<int, int>(_currentWidth, _currentLine + i);
                    }*/
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

        }
    }
}
