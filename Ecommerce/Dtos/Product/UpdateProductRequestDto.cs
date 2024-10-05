using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dtos.Product
{
    public class UpdateProductRequestDto
    {
        [Required(ErrorMessage = "The Name field is required.")]
        [MaxLength(100, ErrorMessage = "The Name field must be a maximum of 100 characters.")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "The Price field is required."), Range(0.01, double.MaxValue, ErrorMessage = "The Price must be greater than 0.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The Description field is required."), MaxLength(500, ErrorMessage = "The Description field must be a maximum of 500 characters.")]
        public required string Description { get; set; }
        [Required(ErrorMessage = "The ImageUrl field is required."), Url(ErrorMessage = "The ImageUrl field must be a valid URL.")]
        public required string ImageUrl { get; set; }
        [Required(ErrorMessage = "The CategoryId field is required.")]
        public int CategoryId { get; set; }
        [Range(1, 5, ErrorMessage = "The Rating must be between 1 and 5.")]
        public int Rating { get; set; } = 0;
        [Range(0, int.MaxValue, ErrorMessage = "TotalSales must be a non-negative number.")]
        public int TotalSales { get; set; } = 0;
    }
}
