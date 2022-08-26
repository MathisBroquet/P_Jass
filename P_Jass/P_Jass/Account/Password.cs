/// Mathis Broquet
/// ETML Lausanne
/// 25.05.2022
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;

namespace P_Jass
{
    class Password
    {
        private int _x;
        private int _y;
        private string _passwordHash;
        public string PasswordHash
        {
            get { return _passwordHash; }
        }

        private Regex _regexPassword;
        private string temp = "";
        private int _maxLength;

        public Password(string password, [Optional]Regex regex)
        {
            _passwordHash = password;
            _maxLength = 20;
            if (regex == null)
            {
                _regexPassword = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            }
            else
            {
                _regexPassword = regex;
            }
        }

        public Password([Optional]Regex regex)
        {
            _passwordHash = "";
            _maxLength = 20;
            if (regex == null)
            {
                _regexPassword = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            }
            else
            {
                _regexPassword = regex;
            }
        }

        public string ChangePass()
        {
            string newName = Extension.ReadLocation(_x + 1, _y - 2, _maxLength, _regexPassword, _passwordHash, $"Votre nom d'utilisateur peut uniquement contenir {_maxLength} lettres et chiffres");

            if (_regexPassword.IsMatch(newName) /*&& /*si le mot de passe correspond */ )
            {
                _passwordHash = newName.Split('\0')[0];
                return newName.Split('\0')[0];
            }
            return "";
        }

        private void Custom(char c1 = '┌', char c2 = '┐', char c3 = '└', char c4 = '┘', char vertical = '│', char horizontal = '─')
        {
            temp = "";
            //Write top custom
            temp += c1;
            for (int x = 0; x < _maxLength; x++)
            {
                temp += horizontal;
            }
            temp += c2 + "\n";
            temp += vertical;
            for (int i = 0; i < _passwordHash.Length; i++)
            {
                temp += "*";
            }
            for (int i = 0; i < _maxLength - _passwordHash.Length; i++)
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
            Title title = new Title(new List<string> { @"__/\\\\\\\\\\\\\_______/\\\\\\\\\________/\\\\\\\\\\\_______/\\\\\\\\\\\____/\\\______________/\\\_______/\\\\\_________/\\\\\\\\\______/\\\\\\\\\\\\____        ", @" _\/\\\/////////\\\___/\\\\\\\\\\\\\____/\\\/////////\\\___/\\\/////////\\\_\/\\\_____________\/\\\_____/\\\///\\\_____/\\\///////\\\___\/\\\////////\\\__       ", @"  _\/\\\_______\/\\\__/\\\/////////\\\__\//\\\______\///___\//\\\______\///__\/\\\_____________\/\\\___/\\\/__\///\\\__\/\\\_____\/\\\___\/\\\______\//\\\_      ", @"   _\/\\\\\\\\\\\\\/__\/\\\_______\/\\\___\////\\\___________\////\\\_________\//\\\____/\\\____/\\\___/\\\______\//\\\_\/\\\\\\\\\\\/____\/\\\_______\/\\\_     ", @"    _\/\\\/////////____\/\\\\\\\\\\\\\\\______\////\\\___________\////\\\_______\//\\\__/\\\\\__/\\\___\/\\\_______\/\\\_\/\\\//////\\\____\/\\\_______\/\\\_    ", @"     _\/\\\_____________\/\\\/////////\\\_________\////\\\___________\////\\\_____\//\\\/\\\/\\\/\\\____\//\\\______/\\\__\/\\\____\//\\\___\/\\\_______\/\\\_   ", @"      _\/\\\_____________\/\\\_______\/\\\__/\\\______\//\\\___/\\\______\//\\\_____\//\\\\\\//\\\\\______\///\\\__/\\\____\/\\\_____\//\\\__\/\\\_______/\\\__  ", @"       _\/\\\_____________\/\\\_______\/\\\_\///\\\\\\\\\\\/___\///\\\\\\\\\\\/_______\//\\\__\//\\\_________\///\\\\\/_____\/\\\______\//\\\_\/\\\\\\\\\\\\/___ ", @"        _\///______________\///________\///____\///////////_______\///////////__________\///____\///____________\/////_______\///________\///__\////////////_____" });
            title.Display();
            title.Animate();
            _x = (System.Console.WindowWidth - _maxLength - 2) / 2;
            _y = (System.Console.WindowHeight + title.Height - 1 - temp.Split("\n").Length) / 2;
            Custom();
            for (int i = 0; i < temp.Split("\n").Length; i++)
            {
                System.Console.SetCursorPosition(_x, _y++);
                System.Console.WriteLine(temp.Split("\n")[i]);
            }
            System.Console.CursorVisible = true;
        }

        public void Confirm()
        {

        }
    }
}
