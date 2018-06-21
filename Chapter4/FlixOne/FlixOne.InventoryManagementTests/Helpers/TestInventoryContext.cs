using System.Collections.Generic;
using System.Linq;
using FlixOne.InventoryManagement.Models;
using FlixOne.InventoryManagement.Repository;

namespace FlixOne.InventoryManagementTests.Helpers
{
    class TestInventoryContext: IInventoryContext
    {
        private readonly IDictionary<string, Book> _seedDictionary;
        private readonly IDictionary<string, Book> _books;

        public TestInventoryContext(IDictionary<string, Book> books)
        {
            _seedDictionary = books.ToDictionary(book => book.Key,
                                                 book => new Book { Id = book.Value.Id, Name = book.Value.Name, Quantity = book.Value.Quantity });
            _books = books;
        }

        public Book[] GetBooks()
        {
            return _books.Values.ToArray();
        }

        public bool AddBook(string name)
        {
            _books.Add(name, new Book() { Name = name });

            return true;
        }

        public bool UpdateQuantity(string name, int quantity)
        {
            _books[name].Quantity += quantity;

            return true;
        }

        public Book[] GetAddedBooks()
        {
            return _books.Where(book => !_seedDictionary.ContainsKey(book.Key)).Select(book => book.Value).ToArray();
        }

        public Book[] GetUpdatedBooks()
        {            
            return _books.Where(book => _seedDictionary[book.Key].Quantity != book.Value.Quantity).Select(book => book.Value).ToArray();
        }
    }
}
