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
            var parallelism = new Parallelism();
            parallelism.GenerateBooks(15000);
            Console.WriteLine("\n\tId\tName\tQty\n");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            parallelism.Sequential();
           // parallelism.PallelVersion();
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            var elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                 ts.Hours, ts.Minutes, ts.Seconds,
                 ts.Milliseconds / 10);
            Console.WriteLine("\n\tProcessing Time " + elapsedTime);

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