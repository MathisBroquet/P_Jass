using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace P_Jass
{
    class Sign
    {
        //Properties
        private char _text;
        public char Text
        {
            get { return _text; }
        }

        private System.ConsoleColor _color;
        public System.ConsoleColor Color
        {
            get { return _color; }
        }

        public  static List<Sign> Signs = new List<Sign>();

        /// <summary>
        /// Creat the sign of the card
        /// </summary>
        /// <param name="text">The symbole of the card (♥, ♦, ♣, ♠)</param>
        /// <param name="color">the color of the symbole</param>
        public Sign(char text, System.ConsoleColor color)
        {
            _text = text;
            _color = color;
            Signs.Add(this);
        }
    }
}
