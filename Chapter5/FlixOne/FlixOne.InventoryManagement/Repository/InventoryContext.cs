using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using FlixOne.InventoryManagement.Models;

namespace FlixOne.InventoryManagement.Repository
{

    public class InventoryContext : IInventoryContext
    {
        public string Name { get; set; }

        public InventoryContext()
        {
            _books = new ConcurrentDictionary<string, Book>();

            //_books = config.GetChildren()
            //               .Select((c, i) => new Book { Id = i, Name = c.Key, Quantity = int.Parse(c.Value) })
            //               .ToDictionary(b => b.Name, b => b);
        }

        private readonly object _lock = new object();        

        private readonly IDictionary<string, Book> _books;

        public Book[] GetBooks()
        {
            return _books.Values.ToArray();
        }

        public bool AddBook(string name)
        {
            _books.Add(name, new Book {Name = name});
            return true;
        }

        public bool UpdateQuantity(string name, int quantity)
        {
            lock (_lock)
            {
                _books[name].Quantity += quantity;
            }

            return true;
        }
    }
}