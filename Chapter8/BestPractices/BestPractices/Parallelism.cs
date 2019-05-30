using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestPractices
{
    internal class Parallelism
    {
        private readonly IDictionary<int, Book> _books;

        public Parallelism()
        {
            _books = new ConcurrentDictionary<int, Book>();
        }

        public void Sequential()
        {
            var books = GetBooks();
            foreach (var book in books) Process(book);
        }

        public void PallelVersion()
        {
            var books = GetBooks();
            Parallel.ForEach(books, Process);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books.Values.ToList();
        }

        public IDictionary<int, Book> GenerateBooks(int howManyBooks)
        {
            for (var cnt = 0; cnt < howManyBooks; cnt++)
            {
                var book = new Book
                {
                    Id = cnt + 1,
                    Name = $"Book#{cnt + 1}",
                    Quantity = (cnt + 1) * 10
                };
                _books.Add(cnt + 1, book);
            }

            return _books;
        }

        internal void Process(Book book)
        {
            Console.WriteLine($"\t{book.Id}\t{book.Name}\t{book.Quantity}");
        }
    }

    internal class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}