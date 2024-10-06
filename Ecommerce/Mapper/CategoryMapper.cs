using Ecommerce.Dtos.Category;
using Ecommerce.Models;

namespace Ecommerce.Mapper
{
    public static class CategoryMapper
    {
        // Map from Category entity to CategoryDto
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                Products= category.Products.Select(C => C.ToProductDto()).ToList(),
                ImageUrl = category.ImageUrl,
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description
            };
        }

        // Map from CreateCategoryDto to Category entity
        public static Category CreateCategoryDto(this CreateCategoryDto categoryDto, string ImageUrl)
        {
            return new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                ImageUrl = ImageUrl,
            };
        }

        // Map from UpdateCategoryDto to Category (for updating an existing category)
        public static void UpdateCategoryDto(this UpdateCategoryRequestDto categoryDto, Category category)
        {
            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;
        }
    }
}
