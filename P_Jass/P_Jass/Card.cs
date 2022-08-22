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

        public void WriteCard(int x, int y)
        {
            Console.ForegroundColor = this._sign.Color;
            if(this._type.Text == "AS")
            {
                Console.SetCursorPosition(x,y);
                Console.Write("╔─╗");
                Console.SetCursorPosition(x, y + 1);
                Console.Write($"│{this._sign.Text}│");
                Console.SetCursorPosition(x, y + 2);
                Console.Write("╚─╝");
            }
            else
            {
                Console.SetCursorPosition(x, y);
                Console.Write($"{this._sign.Text}─{this._sign.Text}");
                Console.SetCursorPosition(x, y + 1);
                Console.Write($"│{this._type.Text}│");
                Console.SetCursorPosition(x, y + 2);
                Console.Write($"{this._sign.Text}─{this._sign.Text}");
            }
        }

        public void Animate(int x, int y)
        {
            int xAvance = (Console.WindowWidth / 2 - x - 3 / 2);
            int yAvance = (Console.WindowHeight / 2 - y - 3 / 2);
            System.Console.ForegroundColor = this._sign.Color;
            if (this._type.Text == "AS")
            {
                Console.SetCursorPosition(x + xAvance, y + yAvance);
                Console.Write("╔─╗");
                Console.SetCursorPosition(x + xAvance, y + yAvance + 1);
                Console.Write($"│{this._sign.Text}│");
                Console.SetCursorPosition(x + xAvance, y + yAvance + 2);
                Console.Write("╚─╝");
            }
            else
            {
                Console.SetCursorPosition(x + xAvance , y + yAvance );
                Console.Write($"{this._sign.Text}─{this._sign.Text}");
                Console.SetCursorPosition(x + xAvance , y + yAvance  + 1);
                Console.Write($"│{this._type.Text}│");
                Console.SetCursorPosition(x + xAvance , y + yAvance  + 2);
                Console.Write($"{this._sign.Text}─{this._sign.Text}");
            }
        }
    }
}
