using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
