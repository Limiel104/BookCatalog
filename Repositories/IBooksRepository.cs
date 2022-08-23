using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookCatalog.Models;

namespace BookCatalog.Repositories
{
    public interface IBooksRepository
    {
        Task<Book> GetBookAsync(Guid id);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Guid id);
    }
}

