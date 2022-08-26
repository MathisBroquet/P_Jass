using System;
using System.Collections.Generic;
using System.Text;

namespace P_Jass
{
    class Type
    {
        //Properties
        private string _text;
        public string Text
        {
            get { return _text; }
        }

        private int _value;
        public int Value
        {
            get { return _value; }
        }

        public static List<Type> Types = new List<Type>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text">The text of the card (AS, K, D, J, 10, 9, 8, 7, 6)</param>
        /// <param name="value">The number of point of the card</param>
        public Type(string text, int value)
        {
            _text = text;
            _value = value;
            Types.Add(this);
        }
    }
}
