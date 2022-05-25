using System;
using System.Collections.Generic;
using System.Text;

namespace P_Jass
{
    public class Menu
    {
        private List<string> _menuNames;
        private MenuStyle _menuStyle;
        private ConsoleColor _color;
        private byte _menuMarginBetween;
        private byte _nbrLines;
        private byte _currentWidth;
        private string[] _lines;
        private byte _currentLine;

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
                for (int i = 0; i < item.Split('\n').Length; i++)
                {
                    _nbrLines++;
                }
            }       //Count the numbers of \n
        }

        public void Display()
        {
            //Properties
            _currentLine = Convert.ToByte(Console.WindowHeight / 2 - (_menuNames.Count) / 2 - ((_menuNames.Count - 1) * _menuMarginBetween) / 2 - _nbrLines / 2);
            Console.ForegroundColor = _color;

            //Write the menu
            foreach (string item in _menuNames)
            {
                _lines = item.Split('\n');
                if (item != _menuNames[0] || item != _menuNames[_menuNames.Count - 1])
                {
                    for (int i = 0; i < _menuMarginBetween; i++)
                    {
                        _currentLine++;
                    }
                }
                for (int i = 0; i < item.Split('\n').Length; i++)
                {
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
                    Console.WriteLine(_lines[i]);
                }
                _currentLine++;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void CustomText(char c1 = '┌', char c2 = '┐', char c3 = '└', char c4 = '┘', char vertical = '│', char horizontal = '─')
        {
            for (int i = 0; i < _menuNames.Count; i++)
            {
                string custom = "";
                //Write top custom
                custom += c1;
                for (int x = 0; x < _menuNames[i].Length; x++)
                {
                    custom += horizontal;
                }
                custom += c2 + "\n";
                //Write middle custom
                custom += vertical + _menuNames[i] + vertical + "\n";
                custom += c3;
                for (int y = 0; y < _menuNames[i].Length; y++)
                {
                    custom += horizontal;
                }
                custom += c4;

                _menuNames[i] = custom;
                _nbrLines += 2;
            }
            _menuMarginBetween += 2;
        }
    }
}
