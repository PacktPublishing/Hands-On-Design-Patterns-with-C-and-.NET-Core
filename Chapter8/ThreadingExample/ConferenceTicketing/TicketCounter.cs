using System;

namespace ConferenceTicketing
{
    internal class TicketCounter
    {
        public static void CounterA() => Console.WriteLine("\tPerson A is collecting ticket from Counter A");
        public static void CounterB() => Console.WriteLine("\tPerson B is collecting ticket from Counter B");
        public static void CounterC() => Console.WriteLine("\tPerson C is collecting ticket from Counter C");

        public static void ShowMessage(char whoAmI)
        {
            Console.WriteLine($"\tPerson {whoAmI} is collecting ticket from Counter {whoAmI}");
        }
    }
}