using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P_Jass.ObserverObservable.Volume
{
    public class VolumeMonitor : IObservable<Volume>
    {
        private List<IObserver<Volume>> _observers;

        public VolumeMonitor()
        {
            _observers = new List<IObserver<Volume>>();
        }

        public IDisposable Subscribe(IObserver<Volume> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            return new Unsubscriber(_observers, observer);
        }
    }
}
