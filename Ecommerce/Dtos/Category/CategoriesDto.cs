namespace Ecommerce.Dtos.Category
{
    public class CategoriesDto
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public required string ImageUrl { get; set; }
        public required string Description { get; set; }
    }
}
