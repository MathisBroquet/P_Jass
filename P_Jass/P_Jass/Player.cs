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
        private bool _done;
        private int _xCards;
        private int _yCards;
        private ConsoleKeyInfo _keyInfo;
        private List<Card> _cards;
        public List<Card> CardsPlayer
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

        /// <summary>
        /// Cut the paquet at a specifique position
        /// </summary>
        /// <param name="packet"></param>
        public void Cut(Paquet paquet)
        {
            int x;
            int y;
            //Write the first big card
            System.Console.Write('╔');
            for (int i = 0; i < 8; i++)
            {
                System.Console.Write('─');
            }
            x = System.Console.CursorLeft + 1;
            y = System.Console.CursorTop;
            System.Console.WriteLine('╗');
            for (int i = 0; i < 8; i++)
            {
                System.Console.Write('│');
                for (int J = 0; J < 8; J++)
                {
                    System.Console.Write(' ');
                }
                System.Console.WriteLine('│');
            }
            System.Console.Write('╚');
            for (int i = 0; i < 8; i++)
            {
                System.Console.Write('─');
            }
            System.Console.Write('╝');

            //write oder border cards
            for (int j = 0; j < paquet.Cards.Count - 1; j++)
            {
                System.Console.SetCursorPosition(x, y);
                System.Console.Write('╗');
                for (int i = 0; i < 8; i++)
                {
                    System.Console.SetCursorPosition(x, y + i + 1);
                    System.Console.Write('│');
                    System.Console.SetCursorPosition(x, y + i + 2);
                }
                System.Console.Write('╝');

                x++;
            }

            //Write the selector in the middle
            int middle = paquet.Cards.Count / 2;
            System.Console.CursorVisible = false;
            System.Console.SetCursorPosition(9 + middle, System.Console.CursorTop + 1);
            System.Console.Write('▲');
            while (!_done)
            {
                _keyInfo = System.Console.ReadKey(true);
                //Try to save the new username
                if (_keyInfo.Key == ConsoleKey.Enter || _keyInfo.Key == ConsoleKey.Spacebar)
                {
                    if (_keyInfo.Key == ConsoleKey.Enter)
                    {
                        if (System.Console.CursorLeft > 9 + 3 && System.Console.CursorLeft < paquet.Cards.Count - 3)
                        {

                            Queue<Card> cards = new Queue<Card>(System.Console.CursorLeft - 9);
                            for (int i = 0; i < System.Console.CursorLeft - 9; i++)
                            {
                                cards.Enqueue(paquet.Cards[i]);
                                paquet.Cards[i] = paquet.Cards[System.Console.CursorLeft - 9 + i - 1];
                            }
                            for (int i = 0; i < System.Console.CursorLeft - 9; i++)
                            {
                                paquet.Cards[System.Console.CursorLeft - 9 + i] = cards.Dequeue();
                            }
                            _done = true;
                        }
                    }
                    else if (_keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        _done = true;
                    }
                }
                //Save the user input for his username
                else if (System.Console.CursorLeft > 9 + 3 && System.Console.CursorLeft < paquet.Cards.Count + 9 - 3 || System.Console.CursorLeft > 9 + 3 && _keyInfo.Key == ConsoleKey.LeftArrow || System.Console.CursorLeft < paquet.Cards.Count - 3 && _keyInfo.Key == ConsoleKey.RightArrow)
                {
                    switch (_keyInfo.Key)
                    {
                        case ConsoleKey.Spacebar:
                            _done = true;
                            break;
                        case ConsoleKey.Enter:
                            _done = true;
                            break;
                        case ConsoleKey.LeftArrow:
                            System.Console.SetCursorPosition(System.Console.CursorLeft - 1, System.Console.CursorTop);
                            System.Console.Write(' ');
                            System.Console.SetCursorPosition(System.Console.CursorLeft - 2, System.Console.CursorTop);
                            System.Console.Write('▲');
                            break;
                        case ConsoleKey.RightArrow:
                            System.Console.SetCursorPosition(System.Console.CursorLeft - 1, System.Console.CursorTop);
                            System.Console.Write(' ');
                            System.Console.SetCursorPosition(System.Console.CursorLeft, System.Console.CursorTop);
                            System.Console.Write('▲');
                            break;
                        default:
                            break;
                    }
                }
            }
            System.Console.Read();
        }

        /// <summary>
        /// The player distribute the cards to all
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="three"></param>
        public void Distribute(Paquet paquet, Player one, Player two, Player three)
        {
            int nbr = 0;
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    one._cards.Add(paquet.Cards[nbr]);
                    nbr++;
                }
                for (int i = 0; i < 3; i++)
                {
                    two._cards.Add(paquet.Cards[nbr]);
                    nbr++;
                }
                for (int i = 0; i < 3; i++)
                {
                    three._cards.Add(paquet.Cards[nbr]);
                    nbr++;
                }
                for (int i = 0; i < 3; i++)
                {
                    this._cards.Add(paquet.Cards[nbr]);
                    nbr++;
                }
            }
        }

        public void Shuffle(Paquet paquet)
        {
            paquet.Cards.Shuffle();
        }

        public void WriteCards(int x, int y)
        {
            System.Console.Clear();
            _xCards = x + 1;
            _yCards = y + 3;
            for (int i = 0; i < this.CardsPlayer.Count; i++)
            {
                this.CardsPlayer[i].WriteCard(x + i * 4, y);
            }
        }

        private byte ChooseCard()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(_xCards, _yCards);

            byte _counter = 0;
            byte _before = 0;

            ConsoleKey key;
            System.Console.CursorVisible = false;
            
            Console.Write('▲');

            do
            {
                key = System.Console.ReadKey(true).Key;
                if (key == ConsoleKey.RightArrow)
                {
                    //Set counter properties
                    _counter++;
                    if (_counter > _cards.Count - 1)
                    {
                        _counter = 0;
                    }

                    //Replace the selector at the next element
                    Console.SetCursorPosition(_xCards + _before * 4, _yCards);
                    Console.Write(' ');
                    Console.SetCursorPosition(_xCards + _counter * 4, _yCards);
                    Console.Write('▲');

                    //Set the new previous before
                    _before = _counter;
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    //Set counter properties
                    _counter--;
                    if (_counter == 255)
                    {
                        _counter = (byte)(_cards.Count - 1);
                    }

                    //Replace the selector at the previous element
                    Console.SetCursorPosition(_xCards + _before * 4, _yCards);
                    Console.Write(' ');
                    Console.SetCursorPosition(_xCards + _counter * 4, _yCards);
                    Console.Write('▲');

                    //Set the new previous before
                    _before = _counter;
                }
            } while (key != ConsoleKey.Enter);

            return _counter;
        }

        public void CardSelection()
        {
            int card = ChooseCard();
            _cards[card].Animate(_xCards + card * 4 - 1, _yCards - 3) ; ;
        }
    }
}
