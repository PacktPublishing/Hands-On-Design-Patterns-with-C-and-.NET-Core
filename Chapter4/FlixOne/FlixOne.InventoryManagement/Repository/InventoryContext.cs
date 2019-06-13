using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using FlixOne.InventoryManagement.Models;

namespace FlixOne.InventoryManagement.Repository
{
    internal interface IInventoryContext
    {
        Book[] GetBooks();
        bool AddBook(string name);
        bool UpdateQuantity(string name, int quantity);
    }

    internal class InventoryContext : IInventoryContext
    {
        protected InventoryContext()
        {
            _books = new ConcurrentDictionary<string, Book>();
        }

        private static InventoryContext _context;
        private static object _lock = new object();

        public static InventoryContext Singleton
        {
            get
            {
                if (_context == null)
                {
                    lock (_lock)
                    {
                        if (_context == null)
                        {
                            _context = new InventoryContext();
                        }
                    }
                }

                return _context;
            }
        }

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