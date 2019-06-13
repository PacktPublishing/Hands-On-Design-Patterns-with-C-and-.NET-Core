using System;
using System.Collections.Generic;
using FlixOne.Web.Models;

namespace FlixOne.Web.Common
{
    public class ProductReporter : IObserver<Product>
    {
        private IDisposable _unsubscriber;
        public List<MessageViewModel> Reporter = new List<MessageViewModel>();

        public ProductReporter(string name) => Name = name;

        public string Name { get; }

        public void OnCompleted()
        {
            PrepReportData(true, $"Report has completed: {Name}");
            Unsubscribe();
        }

        public void OnError(Exception error) => PrepReportData(false, $"Error ocurred with instance: {Name}");

        public void OnNext(Product value)
        {
            var msg =
                $"Reporter:{Name}. Product - Name: {value.Name}, Price:{value.Price},Desc: {value.Description}";
            PrepReportData(true, msg);
        }

        private void PrepReportData(bool isSuccess, string message)
        {
            var model = new MessageViewModel
            {
                MsgId = Guid.NewGuid().ToString(),
                IsSuccess = isSuccess,
                Message = message
            };

            Reporter.Add(model);
        }

        public virtual void Subscribe(IObservable<Product> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe() => _unsubscriber.Dispose();
    }
}