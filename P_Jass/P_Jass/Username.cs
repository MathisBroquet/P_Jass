/// Mathis Broquet
/// ETML Lausanne
/// 25.05.2022
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace P_Jass
{
    class Username
    {
        private int _x;
        private int _y;
        private string _username;
        private List<string> _allUsernames = new List<string>();
        private Regex _regexUsername;
        private string temp = "";
        private int _maxLength;

        public Username(string username, [Optional]Regex regex)
        {
            _username = username;
            _maxLength = 20;
            if (regex == null)
            {
                _regexUsername = new Regex(@"^[\d]+");
            }
            else
            {
                _regexUsername = regex;
            }
        }

        public void ChangeName()
        {
            string newName = AdvencedInput.LimitTextEntery(_x + 1, _y - 2, _maxLength, _regexUsername, _username, $"Votre nom d'utilisateur peut uniquement contenir {_maxLength} lettres et chiffres");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(newName);

            if (_regexUsername.IsMatch(newName) && !_allUsernames.Contains(newName))
            {
                _username = newName;
                _allUsernames.Add(newName);
            }
        }

        private void Custom(char c1 = '┌', char c2 = '┐', char c3 = '└', char c4 = '┘', char vertical = '│', char horizontal = '─')
        {
            //Write top custom
            temp += c1;
            for (int x = 0; x < _maxLength; x++)
            {
                temp += horizontal;
            }
            temp += c2 + "\n";
            temp += vertical + _username;
            for (int i = 0; i < _maxLength - _username.Length; i++)
            {
                temp += " ";
            }
            temp += vertical + "\n";
            //Write bottom custom
            temp += c3;
            for (int y = 0; y < _maxLength; y++)
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
            _x = (Console.WindowWidth - _maxLength - 2) / 2;
            _y = (Console.WindowHeight + title.Height - 1 - temp.Split("\n").Length) / 2;
            Custom();
            for (int i = 0; i < temp.Split("\n").Length; i++)
            {
                Console.SetCursorPosition(_x, _y++);
                Console.WriteLine(temp.Split("\n")[i]);
            }
            Console.CursorVisible = true;
        }
    }
}
