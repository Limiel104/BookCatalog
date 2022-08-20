using System;

namespace BookCatalog.Dtos
{
    public record BookDto
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public int Isbn { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreateDate { get; set; }

    }
}