using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dtos.Category
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Category name is required")]
        [MaxLength(100, ErrorMessage = "Category name cannot exceed 100 characters")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "The Image field is required.")]
        public required IFormFile Image { get; set; }
        [Required, MaxLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public required string Description { get; set; }
    }
}
