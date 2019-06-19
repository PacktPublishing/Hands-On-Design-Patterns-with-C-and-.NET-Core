using System;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var subject = new Subject();
            var greenObserver = new Observer(ConsoleColor.Green);
            var redObserver = new Observer(ConsoleColor.Red);
            var yellowObserver = new Observer(ConsoleColor.Yellow);

            subject.OnQuantityUpdated += greenObserver.ObserverQuantity;
            subject.OnQuantityUpdated += redObserver.ObserverQuantity;
            subject.OnQuantityUpdated += yellowObserver.ObserverQuantity;

            subject.UpdateQuantity(12);
            subject.UpdateQuantity(5);            

            Console.WriteLine("Enter a key to quit.");
            Console.Read();
        }
    }

    public delegate void QuantityUpdated(int quantity);

    class Subject
    {
        private int _quantity = 0;
        
        public event QuantityUpdated OnQuantityUpdated;

        public void UpdateQuantity(int value)
        {
            _quantity += value;

            // alert any observers
            OnQuantityUpdated?.Invoke(_quantity);

        }
    }

    class Observer
    {
        ConsoleColor _color;
        public Observer(ConsoleColor color)
        {
            _color = color;
        }

        internal void ObserverQuantity(int quantity)
        {
            Console.ForegroundColor = _color;
            Console.WriteLine($"I observer the new quantity value of {quantity}.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
