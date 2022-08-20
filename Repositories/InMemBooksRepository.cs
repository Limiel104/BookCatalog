using System;
using System.Collections.Generic;
using System.Linq;
using BookCatalog.Models;

namespace BookCatalog.Repositories
{
    public class InMemBooksRepository
    {
        private readonly List<Book> books = new()
        {
            new Book { Id = Guid.NewGuid(), Name = "Elementarz", 
            Description = "dubisduiusdb ivus du sudv sud vus", 
            Isbn = 1234567890, Price = 12, CreateDate = System.DateTimeOffset.UtcNow },
            
            new Book { Id = Guid.NewGuid(), Name = "Czas do szkoły", 
            Description = "duibfds cuid cius du fuysc sdu csd", 
            Isbn = 1234567890, Price = 23, CreateDate = System.DateTimeOffset.UtcNow },

            new Book { Id = Guid.NewGuid(), Name = "Harry Potter i Czara Ognia", 
            Description = "kjvbds ds cd cush d ", 
            Isbn = 1234567890, Price = 100, CreateDate = System.DateTimeOffset.UtcNow },

            new Book { Id = Guid.NewGuid(), Name = "Zbrodnia i Kara", 
            Description = "Ala ma kota", 
            Isbn = 1234567890, Price = 54, CreateDate = System.DateTimeOffset.UtcNow }
        };


        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        public Book GetBook(Guid id)
        {
            return books.Where(book => book.Id == id).SingleOrDefault();
        }







    }
}