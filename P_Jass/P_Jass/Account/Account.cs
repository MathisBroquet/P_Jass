using System;
using System.Collections.Generic;
using System.Text;

namespace P_Jass
{
    class Account
    {
        private Username _username;
        private Password _password;
        private Dictionary<string, string> _identify = new Dictionary<string, string>(); 
        public Account()
        {
            _username = new Username();
            _password = new Password();
        }
        public void LogIn()
        {
            _username.Display();
            _username.ChangeName();
        }

        public void LogOut()
        {

        }

        public void CreateAccount()
        {
            _username.Display();
            _username.ChangeName();
            _password.Display();
            _password.ChangePass();
            _password.Confirm();
            _identify.Add(_username.username, _password.PasswordHash);
        }
    }
}
