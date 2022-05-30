using System;
using System.Collections.Generic;
using System.Text;

namespace P_Jass.ObserverObservable.Volume
{
    interface IObserver
    {
        int Notify(int volume);
    }
}
