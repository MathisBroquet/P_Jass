using System;
using System.Collections.Generic;
using System.Text;

namespace P_Jass.ObserverObservable.Volume
{
    public struct Volume
    {
        private int _volume;

        public Volume(int volume)
        {
            _volume = volume;
        }

        public int SoundVolume
        { get { return this._volume; } }
    }
}
