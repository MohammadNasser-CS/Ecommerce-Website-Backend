using Ecommerce.Dtos.Product;
using Ecommerce.Models;

namespace Ecommerce.Mapper
{
    public static class ProductMapper
    {
        // Map from Product entity to ProductDto
        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                CategoryName = product.Category.Name,
                Rating = product.Rating,
                TotalSales = product.TotalSales,

            };
        }

        // Map from CreateProductDto to Product entity
        public static Product CreateProductDto(this CreateProductRequestDto productDto, string imageUrl)
        {
            return new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                ImageUrl = imageUrl,
                CategoryId = productDto.CategoryId,
                Rating = productDto.Rating ?? 1,
                TotalSales = productDto.TotalSales ?? 0
            };
        }

        // Map from UpdateProductDto to Product (For updating an existing product)
        public static Product UpdateProductDto(this UpdateProductRequestDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                ImageUrl = productDto.ImageUrl,
                CategoryId = productDto.CategoryId,
                Rating = productDto.Rating,
                TotalSales = productDto.TotalSales
            };

        }
    }
}
