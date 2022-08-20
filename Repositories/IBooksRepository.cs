using System;
using System.Collections.Generic;
using BookCatalog.Models;

namespace BookCatalog.Repositories
 {
    public interface IBooksRepository
        {
            Book GetBook(Guid id);
            IEnumerable<Book> GetBooks();
        }
 }
 
 