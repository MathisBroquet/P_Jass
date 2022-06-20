using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace P_Jass
{
    class Game
    {
        private IPAddress _ipHost;
        private int _port;
        private string _name;
        private int _password;
        private List<Player> _players = new List<Player>(4);
        private List<Game> _games = new List<Game>();
        public List<Game> Games
        {
            get { return _games; }
            set { _games = value; }
        }


        public Game(string name, int password, Player player)
        {
            _ipHost = player.IpAddress;
            _port = 8000;
            _name = name;
            _password = password;
            _players.Add(player);
            _games.Add(this);
        }
    }
}
