using System;
using System.Collections.Generic;
using System.Text;

namespace P_Jass.ObserverObservable.Volume
{
    class Unsubscriber : IDisposable
    {
        private List<IObserver<Volume>> _observers;
        private IObserver<Volume> _observer;

        public Unsubscriber(List<IObserver<Volume>> observers, IObserver<Volume> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (!(_observer == null)) _observers.Remove(_observer);
        }
    }
}
