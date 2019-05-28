using System;
using System.Threading;

namespace ConferenceTicketing
{
    internal class SynchronizedTicketCounter
    {
        public void ShowMessage()
        {
            int personsInQueue = 5;
            lock (this)
            {
                Thread thread = Thread.CurrentThread;
                for (int personCount = 0; personCount < personsInQueue; personCount++)
                {
                    Console.WriteLine($"\tPerson {personCount + 1} is collecting ticket from counter {thread.Name}.");
                }
            }
        }
    }
}