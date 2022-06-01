/// Mathis Broquet
/// ETML Lausanne
/// 25.05.2022
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace P_Jass
{
    class Username
    {
        private int _x;
        private int _y;
        private string _username;
        private List<string> _allUsernames = new List<string>();
        private List<string> _menuUsername;
        private string _regexUsername = @"[\w\d]{1,10}";

        public Username(string username)
        {
            _username = username;
            _menuUsername = new List<string>{ @"__/\\\________/\\\_____/\\\\\\\\\\\____/\\\\\\\\\\\\\\\____/\\\\\\\\\______/\\\\\_____/\\\_____/\\\\\\\\\_____/\\\\____________/\\\\__/\\\\\\\\\\\\\\\_        ", @" _\/\\\_______\/\\\___/\\\/////////\\\_\/\\\///////////___/\\\///////\\\___\/\\\\\\___\/\\\___/\\\\\\\\\\\\\__\/\\\\\\________/\\\\\\_\/\\\///////////__       ", @"  _\/\\\_______\/\\\__\//\\\______\///__\/\\\_____________\/\\\_____\/\\\___\/\\\/\\\__\/\\\__/\\\/////////\\\_\/\\\//\\\____/\\\//\\\_\/\\\_____________      ", @"   _\/\\\_______\/\\\___\////\\\_________\/\\\\\\\\\\\_____\/\\\\\\\\\\\/____\/\\\//\\\_\/\\\_\/\\\_______\/\\\_\/\\\\///\\\/\\\/_\/\\\_\/\\\\\\\\\\\_____     ", @"    _\/\\\_______\/\\\______\////\\\______\/\\\///////______\/\\\//////\\\____\/\\\\//\\\\/\\\_\/\\\\\\\\\\\\\\\_\/\\\__\///\\\/___\/\\\_\/\\\///////______    ", @"     _\/\\\_______\/\\\_________\////\\\___\/\\\_____________\/\\\____\//\\\___\/\\\_\//\\\/\\\_\/\\\/////////\\\_\/\\\____\///_____\/\\\_\/\\\_____________   ", @"      _\//\\\______/\\\___/\\\______\//\\\__\/\\\_____________\/\\\_____\//\\\__\/\\\__\//\\\\\\_\/\\\_______\/\\\_\/\\\_____________\/\\\_\/\\\_____________  ", @"       __\///\\\\\\\\\/___\///\\\\\\\\\\\/___\/\\\\\\\\\\\\\\\_\/\\\______\//\\\_\/\\\___\//\\\\\_\/\\\_______\/\\\_\/\\\_____________\/\\\_\/\\\\\\\\\\\\\\\_ ", @"        ____\/////////_______\///////////_____\///////////////__\///________\///__\///_____\/////__\///________\///__\///______________\///__\///////////////__" };
        }

        public void Display()
        {
            Console.Clear();
            for (int i = 0; i < _menuUsername.Count; i++)
            {
                Console.WriteLine(_menuUsername[i]);
            }
            Animate();
            LimitTextEntery(10);
        }

        private void Animate()
        {
            Console.CursorVisible = false;
            for (int i = 0; i < _menuUsername[0].Length; i++)
            {
                for (int x = 0; x < _menuUsername.Count; x++)
                {
                    if (_menuUsername[x][i] == '/' || _menuUsername[x][i] == '\\')
                    {
                        Console.SetCursorPosition(i, x);
                        Console.WriteLine('_');
                    }
                    if (x%49 == 1)
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
                    Console.SetCursorPosition(i, x);
                    if(_menuUsername[x][i] == '_')
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

        private void ChangeName(string newName)
        {
            if(Regex.IsMatch(newName, _regexUsername) && !_allUsernames.Contains(newName))
            {
                _username = newName;
                _allUsernames.Add(newName);
            }
        }

        private void CaseToUsername()
        {
            _x = 0;
            _y = 0;
            Console.SetCursorPosition(_x, _y);
        }

        public void LimitTextEntery(int limit)
        {

            int nbrCharacter = _username.Length;
            ConsoleKeyInfo key;
            bool max = false;
            do
            {
                key = Console.ReadKey(max);
                if (nbrCharacter <= limit)
                {
                    max = false;
                    nbrCharacter++;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    max = true;
                }
                else
                {
                    max = true;
                }
            } while (key.Key != ConsoleKey.Enter);
        }
    }
}
