using System;
using System.Threading;

namespace BestPractices
{
    internal class TicketCounter
    {
        private static readonly object Object = new object();
        public void ShowMessage()
        {
            const int personsInQueue = 5;
            if (Monitor.TryEnter(Object, 300))
            {
                try
                {
                    var thread = Thread.CurrentThread;
                    for (var personCount = 0; personCount < personsInQueue; personCount++)
                        Console.WriteLine(
                            $"\tPerson {personCount + 1} is collecting ticket from counter {thread.Name}.");
                }
                finally
                {
                    Monitor.Exit(Object);
                }
            }
            else
            {
                Console.WriteLine(
                    $"This statement will execute if the attempt times out to acquire an exclusive lock on {ToString()}   ");
                var thread = Thread.CurrentThread;
                for (var personCount = 0; personCount < personsInQueue; personCount++)
                    Console.WriteLine(
                        $"\tPerson {personCount + 1} is collecting ticket from counter {thread.Name}.");
            }
        }
    }
}