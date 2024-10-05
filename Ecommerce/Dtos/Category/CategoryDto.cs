using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dtos.Category
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public required string ImageUrl { get; set; }
        public required string Description { get; set; }
    }
}
