using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace P_Jass
{
    class Game
    {
        private IPAddress _ipHost;
        private int _port;
        private string _name;
        private int _password;
        private List<Player> _players = new List<Player>(4);
        private Paquet _paquet = new Paquet();

        public Game(string name, int password, Player player)
        {
            _ipHost = player.IpAddress;
            _port = 8000;
            _name = name;
            _password = password;
            _players.Add(player);
        }

        private void LimitTime()
        {

        }
    }
}
