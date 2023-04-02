using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher.Classes
{
    public class Observable<T>
    {
        private List<IObserver<T>> observers = new List<IObserver<T>>();
        private T subject;

        public T Subject
        {
            get => subject; 
            set
            {
                subject = value;
                Notify();
            }
        }

        private void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(subject);
            }
        }

        public void Subscribe(IObserver<T> observer)
        {
            if (!observers.Contains(observer)) { observers.Add(observer); } 
        }
        public void Unsbscribe(IObserver<T> observer)
        {
            if (observers.Contains(observer)) { observers.Remove(observer); }
        }
    }
}
