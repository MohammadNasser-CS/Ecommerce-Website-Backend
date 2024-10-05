using Ecommerce.Dtos.Category;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<String> ImageUploadResult(IFormFile file);
        public Task<List<Category>> GetAllAsync();
        public Task<Category?> GetByIdAsync(int id);
        public Task<Category> CreateAsync(Category category);
        public Task<Category?> UpdateAsync(int id, UpdateCategoryRequestDto updateBook);
        public Task<bool> DeleteAsync(int id);
        Task<bool> CategoryExists(int id);
    }
}
