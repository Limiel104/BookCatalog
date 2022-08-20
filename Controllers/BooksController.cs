using System;
using System.Collections.Generic;
using System.Linq;
using BookCatalog.Dtos;
using BookCatalog.Models;
using BookCatalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Controler
{
    [ApiController]
    [Route("books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository repository;
        
        public BooksController(IBooksRepository repository)
        {
            this.repository = repository;
        }

        // GET /books
        [HttpGet]
        public IEnumerable<BookDto> GetBooks()
        {
            var books = repository.GetBooks().Select( book => book.AsDto());
            
            return books;
        }

        // GET /books/{id}
        [HttpGet("{id}")]
        public ActionResult<BookDto> GetBook(Guid id)
        {
            var book = repository.GetBook(id);

            if (book is null)
            {
                return NotFound();
            }

            return book.AsDto();
        }

        // POST /book
        [HttpPost]
        public ActionResult<BookDto> CreateBook(CreateBookDto bookDto)
        {
            Book book = new(){
                Id = Guid.NewGuid(),
                Title = bookDto.Title,
                Description = bookDto.Description,
                Isbn = bookDto.Isbn,
                Price = bookDto.Price,
                CreateDate = DateTimeOffset.UtcNow
            };

            repository.CreateBook(book);

            return CreatedAtAction(nameof(GetBook), new { id = book.Id}, book.AsDto());
        }

        // PUT /books/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateBook(Guid id, UpdateBookDto bookDto)
        {
            var existingBook = repository.GetBook(id);

            if (existingBook is null)
            {
                return NotFound();
            }

            //with - takes existingBook and make copy of it with following properities modified
            Book updatedBook = existingBook with {
                Title = bookDto.Title,
                Description = bookDto.Description,
                Isbn = bookDto.Isbn,
                Price = bookDto.Price
            };

            repository.UpdateBook(updatedBook);

            return NoContent();

        }

    }
}