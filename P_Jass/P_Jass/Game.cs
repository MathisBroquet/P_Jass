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
        public List<Player> Players
        {
            get { return _players; }
            set { _players = value; }
        }

        public static Paquet _paquet = new Paquet();

        public Game(string name, int password, Player player)
        {
            _port = 8000;
            _name = name;
            _password = password;
            _players.Add(player);
        }

        public void Start()
        {
            Paquet paquet = new Paquet();
            _players[0].Shuffle(paquet);
            _players[3].Cut(paquet);
            _players[0].Distribute(paquet, _players[1], _players[2], _players[3]);
            _players[0].WriteCards(System.Console.WindowWidth / 2 - (9 * 4) / 2, System.Console.WindowHeight - 4);
            _players[0].CardSelection();
        }

        private void LimitTime()
        {

        }
    }
}
