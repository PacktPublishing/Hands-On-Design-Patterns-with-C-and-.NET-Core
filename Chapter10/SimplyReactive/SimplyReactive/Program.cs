using System;
using System.Reactive.Linq;

namespace SimplyReactive
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("\n\tEnter comma separated number (0-9): ");
            var num1 = Console.ReadLine();
            Console.Write("\tEnter comma separated number (0-9): ");
            var num2 = Console.ReadLine();
            var counter1 = num1.ToInts(',');
            var counter2 = num2.ToInts(',');
            TicketCounter ticketCounter = new TicketCounter(counter1, counter2);
            Console.Clear();
            Console.Write("\n\tCounter1:");
            ticketCounter.Print(ticketCounter.Observable1);
            Console.Write("\n\tCounter2:");
            ticketCounter.Print(ticketCounter.Observable2);
            Console.WriteLine("\n\n\n");
            Console.Write("\n\tMerge:\t");
            ticketCounter.Print(ticketCounter.Merge());
            Console.WriteLine("\n\n\n");
            Console.Write("\n\tFilter (<= 3): ");
            ticketCounter.Print(ticketCounter.Filter());
            Console.WriteLine("\n\n\n");
            Console.Write("\n\tMap (+ 3):");
            ticketCounter.Print(ticketCounter.Map());
            Console.Write("\n\n\tPress any key...");
            Console.ReadKey();
        }
    }

    internal class TicketCounter
    {
        private IObservable<int> _observable;
        public int[] Counter1;
        public int[] Counter2;

        public TicketCounter(int[] counter1, int[] counter2)
        {
            Counter1 = counter1;
            Counter2 = counter2;
        }

        public IObservable<int> Observable1 => Counter1.From();
        public IObservable<int> Observable2 => Counter2.From();

        public void Print(IObservable<int> observable) => observable.Subscribe(num => Console.Write($"\t{num}"));

        public IObservable<int> Merge() => _observable = Observable1.Merge(Observable2);

        public IObservable<int> Filter() => _observable = from num in _observable
            where num <= 3
            select num;

        public IObservable<int> Map() => _observable = from num in _observable
            select num + 3;
    }

    public static class Extension
    {
        public static IObservable<T> From<T>(this T[] source) => source.ToObservable();

        public static int[] ToInts(this string commaseparatedStringofInt, char separator) =>
            Array.ConvertAll(commaseparatedStringofInt.Split(separator), int.Parse);
    }
}