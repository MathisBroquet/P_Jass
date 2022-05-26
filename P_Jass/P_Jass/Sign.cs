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
        private Color _color;
        public List<Sign> signs = new List<Sign>();

        /// <summary>
        /// Creat the sign of the card
        /// </summary>
        /// <param name="text">The symbole of the card (♥, ♦, ♣, ♠)</param>
        /// <param name="color">the color of the symbole</param>
        public Sign(char text, Color color)
        {
            _text = text;
            _color = color;
            signs.Add(this);
        }
    }
}
