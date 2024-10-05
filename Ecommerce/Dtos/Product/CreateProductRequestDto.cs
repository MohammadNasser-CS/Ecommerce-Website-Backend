using Ecommerce.Models;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dtos.Product
{
    public class CreateProductRequestDto
    {
        [Required(ErrorMessage = "The Name field is required.")]
        [MaxLength(100, ErrorMessage = "The Name field must be a maximum of 100 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "The Price field is required."), Range(0.01, double.MaxValue, ErrorMessage = "The Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Description field is required."), MaxLength(500, ErrorMessage = "The Description field must be a maximum of 500 characters.")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "The Image field is required.")]
        public IFormFile Image { get; set; } // Correctly defined as IFormFile

        [Required(ErrorMessage = "The CategoryId field is required.")]
        public int CategoryId { get; set; }

        [Range(0, 5, ErrorMessage = "The Rating must be between 0 and 5."), DefaultValue(0)]
        public decimal? Rating { get; set; } // Nullable decimal

        [Range(0, int.MaxValue, ErrorMessage = "TotalSales must be a non-negative number.")]
        public int? TotalSales { get; set; }  // Nullable int
        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}, Description: {Description}, CategoryId: {CategoryId}, Rating: {Rating}, TotalSales: {TotalSales}";
        }
    }

}
