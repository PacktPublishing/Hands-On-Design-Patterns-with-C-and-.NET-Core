using System;
using System.Threading;

namespace BestPractices
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starts here...");
            DeadLock();
            Console.ReadKey();
        }

        private static void DeadLock()
        {
            var ticketCounter = new TicketCounter();
            var counterA = new Thread(ticketCounter.ShowMessage);
            var counterB = new Thread(ticketCounter.ShowMessage);
            var counterC = new Thread(ticketCounter.ShowMessage);
            counterA.Name = "A";
            counterB.Name = "B";
            counterC.Name = "C";
            //counterC.Priority = ThreadPriority.Highest;
            //counterB.Priority = ThreadPriority.Normal;
            //counterA.Priority = ThreadPriority.Lowest;
            counterA.Start();
            counterB.Start();
            counterC.Start();
        }
    }
}