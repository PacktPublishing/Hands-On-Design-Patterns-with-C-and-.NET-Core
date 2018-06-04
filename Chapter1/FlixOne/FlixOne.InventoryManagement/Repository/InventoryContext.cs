using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using FlixOne.InventoryManagement.Models;

namespace FlixOne.InventoryManagement.Repository
{
    // https://msdn.microsoft.com/en-us/library/ff649690.aspx
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

    private static InventoryContext _instance;
        private static object _lock = new object();
public static InventoryContext Instance
{
    get
    {                
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new InventoryContext();
                }
            }
        }
        
        return _instance;
    }
}
       
    private readonly IDictionary<string, Book> _books;        

        public Book[] GetBooks()
        {
            return _books.Values.ToArray();
        }

        public bool AddBook(string name)
        {
            _books.Add(name, new Book { Name = name });
            return true;
        }

        public bool UpdateQuantity(string name, int quantity)
        {
            _books[name].Quantity += quantity;
            return true;
        }
    }
}