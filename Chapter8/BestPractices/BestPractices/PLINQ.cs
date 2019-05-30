using System;
using System.Collections.Generic;
using System.Linq;

namespace BestPractices
{
    internal class Plinq
    {
        private readonly Parallelism _parallelism;

        public Plinq()
        {
            _parallelism = new Parallelism();
        }

        public void Process(bool limitProcessors=false)
        {
            var bookCount = 50000;
            _parallelism.GenerateBooks(bookCount);
            var query = limitProcessors ? BooksCount() : BooksCountHavingStock();
            Console.WriteLine($"\n\t{query.Count()} books out of {bookCount} total books," +
                              "having Qty in stock more than 12250.");
            Console.ReadKey();
        }

        private ParallelQuery<Book> BooksCountHavingStock()
        {
            var books = _parallelism.GetBooks();
            var query = from book in books.AsParallel()
                where book.Quantity > 12250
                select book;
            return query;
        }
        private ParallelQuery<Book> BooksCount()
        {
            var books = _parallelism.GetBooks();
            var query = from book in books.AsParallel().WithDegreeOfParallelism(3)
                where book.Quantity > 12250
                select book;
            return query;
        }
    }
}