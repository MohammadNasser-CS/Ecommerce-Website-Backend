using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dtos.Product
{
    public class UpdateProductRequestDto
    {
        [MaxLength(100, ErrorMessage = "The Name field must be a maximum of 100 characters.")]
        public string? Name { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "The Price must be greater than 0.")]
        public decimal? Price { get; set; }
        [MaxLength(500, ErrorMessage = "The Description field must be a maximum of 500 characters.")]
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public int? Stock { get; set; }
        [Range(1, 5, ErrorMessage = "The Rating must be between 1 and 5.")]
        public int? Rating { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "TotalSales must be a non-negative number.")]
        public int? TotalSales { get; set; }
    }
}
