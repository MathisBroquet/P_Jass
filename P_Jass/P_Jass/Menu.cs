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

        public Menu(List<string> menuNames, MenuStyle menuStyle, ConsoleColor color, byte menuMarginBetween)
        {
            _menuNames = menuNames;
            _menuStyle = menuStyle;
            _color = color;
            _menuMarginBetween = menuMarginBetween;
        }

        public void Display()
        {
            //Properties
            byte _nbrLines = 0;
            foreach (string item in _menuNames)
            {
                for (int i = 0; i < item.Split('\n').Length; i++)
                {
                    _nbrLines++;
                }
            }       //Count the numbers of \n
            byte _currentLine = Convert.ToByte(Console.WindowHeight / 2 - (_menuNames.Count - 1) / 2 - ((_menuNames.Count - 2) * _menuMarginBetween) / 2 - _nbrLines / 2);
            byte _currentWidth = 0;
            string[] _lines;
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
                    if (i == 0)
                    {
                        Console.Write('╔');
                        for (int x = 0; x < _lines[0].Length; x++)
                        {
                            Console.Write('─');
                        }
                        Console.WriteLine('╗');
                    }
                    switch (_menuStyle)
                {
                    case MenuStyle.left:
                        _currentWidth = 0;
                        break;
                    case MenuStyle.center:
                        _currentWidth = Convert.ToByte(Console.WindowWidth / 2 - item.Length / 2);
                        break;
                    case MenuStyle.right:
                        _currentWidth = Convert.ToByte(Console.WindowWidth - item.Length);
                        break;
                    default:
                        _currentWidth = Convert.ToByte(Console.WindowWidth / 2 - item.Length / 2);
                        break;
                }

                    Console.SetCursorPosition(_currentWidth, _currentLine + i);
                    Console.WriteLine(_lines[i]);
                }
                _currentLine++;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void CustomText(string text, char c1 = '┌', char c2 = '┐', char c3 = '└', char c4 = '┘', char vertical = '│', char horizontal = '─')
        {

        }
    }
}
