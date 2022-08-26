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
            Sign newsign = new Sign('♥', System.ConsoleColor.DarkRed);
            newsign = new Sign('♦', System.ConsoleColor.Red);
            newsign = new Sign('♣', System.ConsoleColor.Gray);
            newsign = new Sign('♠', System.ConsoleColor.White);
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
            newtype = new Type("X", 10);
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
            _packetCards.Shuffle();
            _packetCards.Shuffle();
            _packetCards.Shuffle();
            _packetCards.Shuffle();
        }
    }
}
