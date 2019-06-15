using System;
using System.Collections.Generic;
using System.Linq;
using FlixOne.Web.Models;

namespace FlixOne.Web.Common
{
    public class ProductRecorder : IObservable<Product>
    {
        private readonly List<IObserver<Product>> _observers;

        public ProductRecorder() => _observers = new List<IObserver<Product>>();

        public IDisposable Subscribe(IObserver<Product> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        public void Record(Product product)
        {
            var discountRate = product.Discount.FirstOrDefault(x => x.ProductId == product.Id)?.DiscountRate;
            foreach (var observer in _observers)
            {
                if (discountRate == 0 || discountRate - 100 <= 1)
                    observer.OnError(
                        new Exception($"Product:{product.Name} has invalid discount rate {discountRate}"));
                else
                    observer.OnNext(product);
            }
        }

        public void EndRecording()
        {
            foreach (var observer in _observers.ToArray())
                if (_observers.Contains(observer))
                    observer.OnCompleted();

            _observers.Clear();
        }
    }

    internal class Unsubscriber : IDisposable
    {
        private readonly IObserver<Product> _observer;
        private readonly List<IObserver<Product>> _observers;

        public Unsubscriber(List<IObserver<Product>> observers, IObserver<Product> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}