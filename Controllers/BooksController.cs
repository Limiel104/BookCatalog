using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = (await repository.GetBooksAsync()).Select(book => book.AsDto());
            return books;
        }

        // GET /books/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookAsync(Guid id)
        {
            var book = await repository.GetBookAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book.AsDto();
        }

        // POST /book
        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBookAsync(CreateBookDto bookDto)
        {
            Book book = new()
            {
                Id = Guid.NewGuid(),
                Title = bookDto.Title,
                Description = bookDto.Description,
                Isbn = bookDto.Isbn,
                Price = bookDto.Price,
                CreateDate = DateTimeOffset.UtcNow
            };

            await repository.CreateBookAsync(book);

            return CreatedAtAction(nameof(GetBookAsync), new { id = book.Id }, book.AsDto());
        }

        // PUT /books/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(Guid id, UpdateBookDto bookDto)
        {
            var existingBook = await repository.GetBookAsync(id);

            if (existingBook is null)
            {
                return NotFound();
            }

            //with - takes existingBook and make copy of it with following properities modified
            Book updatedBook = existingBook with
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                Isbn = bookDto.Isbn,
                Price = bookDto.Price
            };

            await repository.UpdateBookAsync(updatedBook);

            return NoContent();
        }

        // DELETE /books/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(Guid id)
        {
            var existingBook = await repository.GetBookAsync(id);

            if (existingBook is null)
            {
                return NotFound();
            }

            await repository.DeleteBookAsync(id);

            return NoContent();
        }
    }
}