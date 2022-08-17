using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P_Jass
{
    /// <summary>
    /// Initialize a paquet of cards
    /// </summary>
    class Paquet
    {
        //Properties
        private List<Card> _packetCards = new List<Card>(36);
        private bool _done;
        private ConsoleKeyInfo _keyInfo;
        public List<Card> Cards
        {
            get { return _packetCards; }
            set { _packetCards = value; }
        }

        /// <summary>
        /// Generate all the signs
        /// </summary>
        private void GenerateSign()
        {
            Sign newsign = new Sign('♥', System.Drawing.Color.DarkRed);
            newsign = new Sign('♦', System.Drawing.Color.DarkRed);
            newsign = new Sign('♣', System.Drawing.Color.White);
            newsign = new Sign('♠', System.Drawing.Color.White);
        }

        /// <summary>
        /// Generate all the types
        /// </summary>
        private void GenerateType()
        {
            Type newtype = new Type("AS", 11);
            newtype = new Type("K", 4);
            newtype = new Type("D", 3);
            newtype = new Type("J", 2);
            newtype = new Type("10", 10);
            newtype = new Type("9", 0);
            newtype = new Type("8", 0);
            newtype = new Type("7", 0);
            newtype = new Type("6", 0);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cards">List of cards for a paquet (36)</param>
        public Paquet()
        {
            GenerateSign();
            GenerateType();
            for (int i = 0; i < Sign.Signs.Count; i++)
            {
                for (int j = 0; j < Type.Types.Count; j++)
                {
                    _packetCards.Add(new Card(Type.Types[j], Sign.Signs[i], false));
                }
            }
        }

        /// <summary>
        /// Shuffle the cards
        /// </summary>
        public void Shuffle()
        {
            Random rdm = new Random();
            _packetCards.OrderBy(item => rdm.Next());
        }

        /// <summary>
        /// Cut the paquet at a specifique position
        /// </summary>
        /// <param name="packet"></param>
        public void Cut()
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
            for (int j = 0; j < _packetCards.Count - 1; j++)
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
            int middle = _packetCards.Count / 2;
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
                        if (System.Console.CursorLeft > 9 + 3 && System.Console.CursorLeft < _packetCards.Count - 3)
                        {

                            Queue<Card> cards = new Queue<Card>(System.Console.CursorLeft - 9);
                            for (int i = 0; i < System.Console.CursorLeft - 9; i++)
                            {
                                cards.Enqueue(_packetCards[i]);
                                _packetCards[i] = _packetCards[System.Console.CursorLeft - 9 + i - 1];
                            }
                            for (int i = 0; i < System.Console.CursorLeft - 9; i++)
                            {
                                _packetCards[System.Console.CursorLeft - 9 + i] = cards.Dequeue();
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
                else if (System.Console.CursorLeft > 9 + 3 && System.Console.CursorLeft < _packetCards.Count + 9 - 3 || System.Console.CursorLeft > 9 + 3 && _keyInfo.Key == ConsoleKey.LeftArrow || System.Console.CursorLeft < _packetCards.Count - 3 && _keyInfo.Key == ConsoleKey.RightArrow)
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

        public void Distribute(Player one, Player two, Player three, Player four)
        {
            int nbr = 0;
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    one.Cards.Add(_packetCards[nbr]);
                    nbr++;
                }
                for (int i = 0; i < 3; i++)
                {
                    two.Cards.Add(_packetCards[nbr]);
                    nbr++;
                }
                for (int i = 0; i < 3; i++)
                {
                    three.Cards.Add(_packetCards[nbr]);
                    nbr++;
                }
                for (int i = 0; i < 3; i++)
                {
                    four.Cards.Add(_packetCards[nbr]);
                    nbr++;
                }
            }
        }
    }
}
