using BookCatalog.Dtos;
using BookCatalog.Models;

namespace BookCatalog
{
    public static class Extensions
    {
        public static BookDto AsDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Isbn = book.Isbn,
                Price = book.Price,
                CreateDate = book.CreateDate
            };
        }
    }
}