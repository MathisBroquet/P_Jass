using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace P_Jass
{
    class Card
    {
        //Properties
        private Type _type;
        private Sign _sign;
        private bool _atout;
        public bool atout { set => _atout = value; }

        public List<Card> packet = new List<Card>(36);
        private ConsoleKeyInfo keyInfo;
        private bool done;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Is the value of the card</param>
        /// <param name="sign">Is the symbole of the card</param>
        /// <param name="atout">Is atout or not</param>
        public Card(Type type, Sign sign, bool atout)
        {
            _type = type;
            _sign = sign;
            _atout = atout;
            packet.Add(this);
        }

        /// <summary>
        /// Shuffle the cards
        /// </summary>
        public void ShuffleCards()
        {
            Random rdm = new Random();

            packet.OrderBy(item => rdm.Next());
        }

        public void GiveCards()
        {

        }

        public void Cut(List<Card> packet)
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
            for (int j = 0; j < packet.Count - 1; j++)
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
            int middle = packet.Count / 2;
            System.Console.CursorVisible = false;
            System.Console.SetCursorPosition(9 + middle, System.Console.CursorTop + 1);
            System.Console.Write('▲');
            while (!done)
            {
                keyInfo = System.Console.ReadKey(true);
                //Try to save the new username
                if (keyInfo.Key == ConsoleKey.Enter || keyInfo.Key == ConsoleKey.Spacebar)
                {
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        if (System.Console.CursorLeft > 9 + 3 && System.Console.CursorLeft < packet.Count - 3)
                        {
                        
                            Queue<Card> cards = new Queue<Card>(System.Console.CursorLeft - 9);
                            for (int i = 0; i < System.Console.CursorLeft - 9; i++)
                            {
                                cards.Enqueue(packet[i]);
                                packet[i] = packet[System.Console.CursorLeft - 9 + i - 1];
                            }
                            for (int i = 0; i < System.Console.CursorLeft - 9; i++)
                            {
                                packet[System.Console.CursorLeft - 9 + i] = cards.Dequeue();
                            }
                            done = true;
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        done = true;
                    }
                }
                //Save the user input for his username
                else if (System.Console.CursorLeft > 9 + 3 && System.Console.CursorLeft < packet.Count + 9 - 3 || System.Console.CursorLeft > 9 + 3 && keyInfo.Key == ConsoleKey.LeftArrow || System.Console.CursorLeft < packet.Count - 3 && keyInfo.Key == ConsoleKey.RightArrow)
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Spacebar:
                            done = true;
                            break;
                        case ConsoleKey.Enter:
                            done = true;
                            break;
                        case ConsoleKey.LeftArrow:
                            System.Console.SetCursorPosition(System.Console.CursorLeft - 1, System.Console.CursorTop);
                            System.Console.Write(' ');
                            System.Console.SetCursorPosition(System.Console.CursorLeft - 2, System.Console.CursorTop);
                            System.Console.Write("▲");
                            break;
                        case ConsoleKey.RightArrow:
                            System.Console.SetCursorPosition(System.Console.CursorLeft - 1, System.Console.CursorTop);
                            System.Console.Write(' ');
                            System.Console.SetCursorPosition(System.Console.CursorLeft, System.Console.CursorTop);
                            System.Console.Write("▲");
                            break;
                        default:
                            break;
                    }
                }
            }
            System.Console.Read();
        }
    }
}
