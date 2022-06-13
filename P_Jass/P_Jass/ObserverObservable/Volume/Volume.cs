using System;
using System.Collections.Generic;
using System.Text;

namespace P_Jass
{
    class Volume
    {
        //Properties
        private int _volume;
        private List<Tuple<string, int>> _sounds;
        public List<Tuple<string, int>> Sounds
        {
            set { _sounds = value; }
        }

        public Volume(int volume)
        {
            _sounds = new List<Tuple<string, int>>();
            _volume = volume;
        }

        public void Increase(int bigger)
        {
            if (_volume + bigger <= 100)
            {
                for (int i = 0; i < _sounds.Count - 1; i++)
                {
                    _sounds[i] = new Tuple<string, int>(_sounds[i].Item1, _volume + bigger);
                }
                _volume += bigger;
            }
            else
            {
                for (int i = 0; i < _sounds.Count - 1; i++)
                {
                    _sounds[i] = new Tuple<string, int>(_sounds[i].Item1, 100);
                }
                _volume = 100;
            }
        }

        public void Decrease(int smaller)
        {
            if(_volume - smaller >= 0)
            {
                for (int i = 0; i < _sounds.Count - 1; i++)
                {
                    _sounds[i] = new Tuple<string, int>(_sounds[i].Item1, _volume - smaller);
                }
                _volume -= smaller;
            }
            else
            {
                for (int i = 0; i < _sounds.Count - 1; i++)
                {
                    _sounds[i] = new Tuple<string, int>(_sounds[i].Item1, 0);
                }
                _volume = 0;
            }
        }
    }
}
