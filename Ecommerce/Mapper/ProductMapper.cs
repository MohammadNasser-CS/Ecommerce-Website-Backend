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
                Stock = product.Stock,
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
                Stock = productDto.Stock ?? 1,
                Rating = productDto.Rating ?? 1,
                TotalSales = productDto.TotalSales ?? 0
            };
        }

        public static void UpdateProduct(this Product product, UpdateProductRequestDto productDto)
        {
            product.Name = productDto.Name ?? product.Name;
            product.Price = productDto.Price ?? product.Price;
            product.Description = productDto.Description ?? product.Description;
            product.Stock = productDto.Stock ?? product.Stock;
            product.Rating = productDto.Rating ?? product.Rating;
            product.TotalSales = productDto.TotalSales ?? product.TotalSales;
            product.CategoryId = productDto.CategoryId ?? product.CategoryId;
        }
    }
}
