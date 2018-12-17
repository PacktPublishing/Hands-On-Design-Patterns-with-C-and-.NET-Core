using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using FlixOne.InventoryManagement.Models;

namespace FlixOne.InventoryManagement.Repository
{
    public interface IInventoryReadContext
    {
        Book[] GetBooks();        
    }

    public interface IInventoryWriteContext
    {
        bool AddBook(string name);
        bool UpdateQuantity(string name, int quantity);
    }

    public class InventoryContext : IInventoryWriteContext, IInventoryReadContext
    {
        public string Name { get; set; }

        public InventoryContext()
        {
            _books = new ConcurrentDictionary<string, Book>();
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