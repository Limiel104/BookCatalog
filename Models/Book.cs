using System;

namespace BookCatalog.Models
{
    public record Book
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public int Isbn { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreateDate { get; init; }

    }
}