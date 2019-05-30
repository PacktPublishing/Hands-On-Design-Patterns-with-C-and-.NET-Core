using System;
using System.Diagnostics;
using System.Threading;

namespace BestPractices
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console.WriteLine();
            //ProcessTickets();
            //Console.ReadKey();
            ParallelismExample();
        }

        private static void ParallelismExample()
        {
            Plinq plinq= new Plinq();
            plinq.Process(true);
        }

        private static void Parallelism()
        {
            var parallelism = new Parallelism();
            parallelism.GenerateBooks(19);
            Console.WriteLine("\n\tId\tName\tQty\n");
            //parallelism.Sequential();
            parallelism.PallelVersion();
            Console.WriteLine($"\n\tTotal Processes Running on the machine:{Environment.ProcessorCount}\n");
            Console.WriteLine("\tProcessing complete. Press any key to exit.");
            Console.ReadKey();
        }

        private static void ProcessTickets()
        {
            var ticketCounter = new TicketCounter();
            var counterA = new Thread(ticketCounter.ShowMessage);
            var counterB = new Thread(ticketCounter.ShowMessage);
            var counterC = new Thread(ticketCounter.ShowMessage);
            counterA.Name = "A";
            counterB.Name = "B";
            counterC.Name = "C";
            counterC.Priority = ThreadPriority.Highest;
            counterB.Priority = ThreadPriority.Normal;
            counterA.Priority = ThreadPriority.AboveNormal;
            counterA.Start();
            counterB.Start();
            counterC.Start();
        }
    }
}