using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace ConferenceTicketing
{
    internal class AsyncAwait
    {
        public async Task ShowMessage()
        {
            Console.WriteLine("\tServing messages!");
            await Task.Delay(1000);
           
        }
        public bool UpdateQuantity(string name, int quantity)
        {
            var book = new Dictionary<string, int>().ToImmutableDictionary();
            var modified = book.Add(name, quantity);
            return true;
        }
    }
}