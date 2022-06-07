/// Mathis Broquet
/// ETML Lausanne
/// 25.05.2022
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P_Jass
{
    class Username
    {
        private int _x;
        private int _y;
        private string _username;
        private List<string> _allUsernames = new List<string>();
        private string _regexUsername = @"[\w\d]{1,10}";
        private string temp = "";
        private int _limit;

        public Username(string username)
        {
            _username = username;
            _limit = 20;
        }

        private void ChangeName(string newName)
        {
            if(Regex.IsMatch(newName, _regexUsername) && !_allUsernames.Contains(newName))
            {
                _username = newName;
                _allUsernames.Add(newName);
            }
        }

        private void Custom(char c1 = '┌', char c2 = '┐', char c3 = '└', char c4 = '┘', char vertical = '│', char horizontal = '─')
        {
            //Write top custom
            temp += c1;
            for (int x = 0; x < _limit; x++)
            {
                temp += horizontal;
            }
            temp += c2 + "\n";
            temp += vertical + _username;
            for (int i = 0; i < _limit - _username.Length; i++)
            {
                temp += " ";
            }
            temp += vertical + "\n";
            //Write bottom custom
            temp += c3;
            for (int y = 0; y < _limit; y++)
            {
                temp += horizontal;
            }
            temp += c4;
        }

        public void Display()
        {
            Title title = new Title();
            title.Display();
            title.Animate();
            _x = (Console.WindowWidth - _limit - 2) / 2;
            _y = (Console.WindowHeight + title.Height - 1 - temp.Split("\n").Length) / 2;
            Custom();
            for (int i = 0; i < temp.Split("\n").Length; i++)
            {
                Console.SetCursorPosition(_x, _y++);
                Console.WriteLine(temp.Split("\n")[i]);
            }
            Console.CursorVisible = true;
            Console.SetCursorPosition(_x + _username.Length + 1, _y - 2);
            LimitTextEntery(_limit);
        }
        public void LimitTextEntery(int limit)
        {
            _limit = limit;
            char[] chars = new char[limit];
            ConsoleKeyInfo keyInfo;
            int count = _username.Length;
            int deplace = _username.Length;
            bool done = false;

            while (!done)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    done = true;
                }
                else if(Console.CursorLeft < _limit + _x + 1 && Console.CursorLeft >= _x + 1 || keyInfo.Key == ConsoleKey.Backspace)
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Backspace:
                            if (count > 0)
                            {
                                Console.Write("\b \b");
                                if (deplace >= _x + 1 && deplace < _x + _limit + 1)
                                {
                                    deplace--;
                                }
                                count--;
                            }
                            break;
                        case ConsoleKey.Enter:
                            done = true;
                            break;
                        case ConsoleKey.LeftArrow:
                            if(deplace >= _x + 1 && deplace <= count)
                            {
                                deplace--;
                                Console.SetCursorPosition(deplace + _x + 1, _y);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (deplace < _x + _limit + 1 && deplace <= count)
                            {
                                deplace++;
                                Console.SetCursorPosition(deplace + _x + 1, _y);
                            }
                            break;
                        default:
                            if (count < chars.Length)
                            {
                                if (deplace != count)
                                {
                                    for (int i = 0; i < Math.Abs(deplace-count); i++)
                                    {
                                        chars[count + 1 + i] = chars[count + i];
                                    }

                                }
                                chars[count] = keyInfo.KeyChar;
                                Console.Write(keyInfo.KeyChar);
                                deplace++;
                                count++;
                            }
                            break;
                    }
                }
                else
                {

                }
            }

            Console.WriteLine(chars);
            //do
            //{
            //    key = Console.ReadKey(max);
            //    if (key.Key == ConsoleKey.Backspace && nbrCharacter > 1)
            //    {
            //        cursor--;
            //        nbrCharacter--;
            //        Console.SetCursorPosition(_x + nbrCharacter, _y - 2);
            //        Console.Write(' ');
            //        Console.SetCursorPosition(_x + nbrCharacter, _y - 2);
            //        max = true;
            //    }
            //   else if (key.Key == ConsoleKey.LeftArrow && cursor > 1)
            //    {

            //    }
            //    else if (key.Key == ConsoleKey.RightArrow && cursor <= limit)
            //    {

            //    }
            //    else if (nbrCharacter <= limit)
            //    {
            //        max = false;
            //        cursor++;
            //        nbrCharacter++;
            //    }
            //    else
            //    {
            //        max = true;
            //    }
            //    value += "";
            //} while (key.Key != ConsoleKey.Enter);
        }
    }
}
