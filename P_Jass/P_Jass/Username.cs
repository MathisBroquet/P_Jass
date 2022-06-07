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
        private int _maxLengt;

        public Username(string username)
        {
            _username = username;
            _maxLengt = 20;
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
            for (int x = 0; x < _maxLengt; x++)
            {
                temp += horizontal;
            }
            temp += c2 + "\n";
            temp += vertical + _username;
            for (int i = 0; i < _maxLengt - _username.Length; i++)
            {
                temp += " ";
            }
            temp += vertical + "\n";
            //Write bottom custom
            temp += c3;
            for (int y = 0; y < _maxLengt; y++)
            {
                temp += horizontal;
            }
            temp += c4;
        }

        public void Display()
        {
            Title title = new Title();
            title.Display();
            //title.Animate();
            _x = (Console.WindowWidth - _maxLengt - 2) / 2;
            _y = (Console.WindowHeight + title.Height - 1 - temp.Split("\n").Length) / 2;
            Custom();
            for (int i = 0; i < temp.Split("\n").Length; i++)
            {
                Console.SetCursorPosition(_x, _y++);
                Console.WriteLine(temp.Split("\n")[i]);
            }
            Console.CursorVisible = true;
            LimitTextEntery(_x + 1, _y - 2, _maxLengt);
        }
        public String LimitTextEntery(int left, int top, int maxLength)
        {
            //Properties
            _maxLengt = maxLength;
            char[] chars = new char[maxLength];
            ConsoleKeyInfo keyInfo;
            int count = _username.Length;
            int deplace = _username.Length;
            bool done = false;
            for (int i = 0; i < _username.Length; i++)
            {
                chars[i] = _username[i];
            }   //Put the actuel username
            Console.SetCursorPosition(left + count - 1, top);

            //Modify the username
            while (!done)
            {
                keyInfo = Console.ReadKey(true);

                //Try to save the new username
                if (keyInfo.Key == ConsoleKey.Enter && Regex.IsMatch(chars.ToString(), _regexUsername))
                {
                    done = true;
                }
                else if(Console.CursorLeft < _maxLengt + left && Console.CursorLeft >= left || keyInfo.Key == ConsoleKey.Backspace)
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Backspace:
                            if (count > 0)
                            {
                                Console.Write("\b \b");
                                if (deplace >= 1 && deplace < _maxLengt + 1)
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
                            if(left + deplace > left && deplace <= count)//
                            {
                                deplace--;
                                Console.SetCursorPosition(deplace + left, top);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (deplace < _x + _maxLengt + 1 && deplace <= count)
                            {
                                deplace++;
                                Console.SetCursorPosition(deplace + left, top);
                            }
                            break;
                        default:
                            if (count < chars.Length)
                            {
                                if (deplace != count && count < maxLength - 1)
                                {
                                    for (int i = 0; i <= count - deplace; i++)
                                    {
                                        chars[count - i + 1] = chars[ count - i];
                                    }

                                    chars[deplace] = keyInfo.KeyChar;

                                    Console.SetCursorPosition(left, top);
                                    for (int i = 0; i < chars.Length; i++)
                                    {
                                        Console.Write(chars[i]);
                                    }
                                    Console.SetCursorPosition(left + deplace + 1, top);
                                }
                                else
                                {
                                    chars[count] = keyInfo.KeyChar;
                                    Console.Write(keyInfo.KeyChar);
                                }
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
            return new String(chars);
        }
    }
}
