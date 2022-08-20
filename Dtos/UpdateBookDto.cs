using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Dtos
{
    public record UpdateBookDto
    {
        [Required]
        public string Title { get; init; }
        [Required]
        public string Description { get; init; }
        [Required]
        [Range(100000000,9999999999)]
        public long Isbn { get; init; }
        [Required]
        [Range(1,1000)]
        public decimal Price { get; init; }
    }
}