using System;
using System.Collections.Generic;
using System.Text;

namespace P_Jass.ObserverObservable.Volume
{
    abstract class Observable
    {
        private List<IObserver> _observers = new List<IObserver>();
    }
}
