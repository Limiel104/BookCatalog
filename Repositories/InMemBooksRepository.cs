using System;
using System.Collections.Generic;
using System.Linq;
using BookCatalog.Models;

namespace BookCatalog.Repositories
{
    public class InMemBooksRepository : IBooksRepository
    {
        private readonly List<Book> books = new()
        {
            new Book { Id = Guid.NewGuid(), Title = "Elementarz",
            Description = "dubisduiusdb ivus du sudv sud vus",
            Isbn = 1234567890, Price = 12, CreateDate = System.DateTimeOffset.UtcNow },

            new Book { Id = Guid.NewGuid(), Title = "Czas do szkoły",
            Description = "duibfds cuid cius du fuysc sdu csd",
            Isbn = 1234567890, Price = 23, CreateDate = System.DateTimeOffset.UtcNow },

            new Book { Id = Guid.NewGuid(), Title = "Harry Potter i Czara Ognia",
            Description = "kjvbds ds cd cush d ",
            Isbn = 564864274, Price = 100, CreateDate = System.DateTimeOffset.UtcNow },

            new Book { Id = Guid.NewGuid(), Title = "Zbrodnia i Kara",
            Description = "Ala ma kota",
            Isbn = 368357853, Price = 54, CreateDate = System.DateTimeOffset.UtcNow }
        };


        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        public Book GetBook(Guid id)
        {
            return books.Where(book => book.Id == id).SingleOrDefault();
        }

        public void CreateBook(Book book)
        {
            books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var index = books.FindIndex(existingBook => existingBook.Id == book.Id);

            books[index] = book;
        }

        public void DeleteBook(Guid id)
        {
            var index = books.FindIndex(existingBook => existingBook.Id == id);

            books.RemoveAt(index);
        }
    }
}