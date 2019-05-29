using System;
using System.Threading;

namespace ConferenceTicketing
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine();
            //MultiThreadedMethod();
            //SynchronizedMethod();
            ShowAsyncMessage();
            Console.ReadLine();
        }

        private static void MultiThreadedMethod()
        {
            var counterA = new Thread(TicketCounter.CounterA);
            var counterB = new Thread(TicketCounter.CounterB);
            var counterC = new Thread(TicketCounter.CounterC);
            Console.WriteLine("\t3-counters are serving...");
            counterA.Start();
            counterB.Start();
            counterC.Start();
            Console.WriteLine("\tNext person from row");
        }
        private static void SynchronizedMethod()
        {
            SynchronizedTicketCounter ticketCounter = new SynchronizedTicketCounter();
            Thread counterA = new Thread(ticketCounter.ShowMessage);
            Thread counterB = new Thread(ticketCounter.ShowMessage);
            Thread counterC = new Thread(ticketCounter.ShowMessage);
            counterA.Name = "A";
            counterB.Name = "B";
            counterC.Name = "C";
            counterC.Priority = ThreadPriority.Highest;
            counterB.Priority = ThreadPriority.Normal;
            counterA.Priority = ThreadPriority.Lowest;
            counterA.Start();
            counterB.Start();
            counterC.Start();
        }
        private static void ShowAsyncMessage()
        {
            AsyncAwait asyncAwait = new AsyncAwait();
            var showMessage = asyncAwait.ShowMessage();
        }
    }
}