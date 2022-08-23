using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await Task.FromResult(books);
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            var book = books.Where(book => book.Id == id).SingleOrDefault();
            return await Task.FromResult(book);
        }

        public async Task CreateBookAsync(Book book)
        {
            books.Add(book);
            await Task.CompletedTask;
        }

        public async Task UpdateBookAsync(Book book)
        {
            var index = books.FindIndex(existingBook => existingBook.Id == book.Id);
            books[index] = book;
            await Task.CompletedTask;
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var index = books.FindIndex(existingBook => existingBook.Id == id);
            books.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}