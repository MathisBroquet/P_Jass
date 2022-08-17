using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace P_Jass
{
    class Player
    {
        private string _pseudo;
        private IPAddress _ipAddress;
        private string _classe;
        private string _identifiant;
        private bool _atout;
        private bool _shuffle;
        private bool _cut;
        private List<Card> _cards;
        public List<Card> Cards
        {
            get { return _cards; }
            set { _cards = value; }
        }

        public IPAddress IpAddress
        {
            get { return _ipAddress; }
        }

        public Player(string pseudo, bool atout = false, bool shuffle = false, bool cut = false)
        {
            _pseudo = pseudo;
            _atout = atout;
            _shuffle = shuffle;
            _cut = cut;
            _ipAddress = Dns.GetHostEntry(Environment.MachineName).AddressList[Dns.GetHostEntry(Environment.MachineName).AddressList.Length - 1];
            if (Environment.UserDomainName == "ETMLNET")
            {
                _classe = Environment.MachineName.Substring(4, 4);
            }
            else
            {
                _classe = "";
            }
            _identifiant = Environment.UserName;
            _cards = new List<Card>(9);
        }

        public void CreateGame(string name, int password)
        {
            Game game = new Game(name, password, this);
        }

        public void JoinGame(string name, int password)
        {

        }
    }
}
