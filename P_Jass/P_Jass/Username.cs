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
            string newName = P_Jass.Console.ReadLocation(_x + 1, _y - 2, _maxLength, _regexUsername, _username, $"Votre nom d'utilisateur peut uniquement contenir {_maxLength} lettres et chiffres");

            if (_regexUsername.IsMatch(newName) && !_allUsernames.Contains(newName))
            {
                _username = newName.Split('\0')[0];
                _allUsernames.Add(_username);
            }
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
            Title title = new Title(new List<string> { @"__/\\\________/\\\_____/\\\\\\\\\\\____/\\\\\\\\\\\\\\\____/\\\\\\\\\______/\\\\\_____/\\\_____/\\\\\\\\\_____/\\\\____________/\\\\__/\\\\\\\\\\\\\\\_        ", @" _\/\\\_______\/\\\___/\\\/////////\\\_\/\\\///////////___/\\\///////\\\___\/\\\\\\___\/\\\___/\\\\\\\\\\\\\__\/\\\\\\________/\\\\\\_\/\\\///////////__       ", @"  _\/\\\_______\/\\\__\//\\\______\///__\/\\\_____________\/\\\_____\/\\\___\/\\\/\\\__\/\\\__/\\\/////////\\\_\/\\\//\\\____/\\\//\\\_\/\\\_____________      ", @"   _\/\\\_______\/\\\___\////\\\_________\/\\\\\\\\\\\_____\/\\\\\\\\\\\/____\/\\\//\\\_\/\\\_\/\\\_______\/\\\_\/\\\\///\\\/\\\/_\/\\\_\/\\\\\\\\\\\_____     ", @"    _\/\\\_______\/\\\______\////\\\______\/\\\///////______\/\\\//////\\\____\/\\\\//\\\\/\\\_\/\\\\\\\\\\\\\\\_\/\\\__\///\\\/___\/\\\_\/\\\///////______    ", @"     _\/\\\_______\/\\\_________\////\\\___\/\\\_____________\/\\\____\//\\\___\/\\\_\//\\\/\\\_\/\\\/////////\\\_\/\\\____\///_____\/\\\_\/\\\_____________   ", @"      _\//\\\______/\\\___/\\\______\//\\\__\/\\\_____________\/\\\_____\//\\\__\/\\\__\//\\\\\\_\/\\\_______\/\\\_\/\\\_____________\/\\\_\/\\\_____________  ", @"       __\///\\\\\\\\\/___\///\\\\\\\\\\\/___\/\\\\\\\\\\\\\\\_\/\\\______\//\\\_\/\\\___\//\\\\\_\/\\\_______\/\\\_\/\\\_____________\/\\\_\/\\\\\\\\\\\\\\\_ ", @"        ____\/////////_______\///////////_____\///////////////__\///________\///__\///_____\/////__\///________\///__\///______________\///__\///////////////__" });
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
    }
}
