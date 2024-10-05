using CloudinaryDotNet.Actions;
using Ecommerce.Dtos.Product;
using Ecommerce.Helpers;
using Ecommerce.Models;

namespace Ecommerce.Interfaces
{
    public interface IProductRepository
    {
        public Task<String> ImageUploadResult(IFormFile file);
        Task<Product> CreateProductAsync(Product product);
        Task<bool> ProductExists(int productId);
        Task<Product?> GetProductByIdAsync(int productId);
        public Task<List<Product>> GetAllAsync(ProductQueryObject productQuery);
        public Task<Product?> UpdateAsync(int id, UpdateProductRequestDto updateProduct);
        public Task<Product?> DeleteAsyny(int id);
    }
}
