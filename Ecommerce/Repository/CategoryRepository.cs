using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Ecommerce.Data;
using Ecommerce.Dtos.Category;
using Ecommerce.Interfaces;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EcommerceContext context;
        private readonly Cloudinary _cloudinary;
        public CategoryRepository(EcommerceContext context, Cloudinary cloudinary)
        {
            this.context = context;
            this._cloudinary = cloudinary;
        }
        public async Task<List<Category>> GetAllAsync()
        {
            return await context.Categories.ToListAsync();
        }
        public async Task<Category?> GetByIdAsync(int id)
        {
            return await context.Categories.Include(C => C.Products).FirstOrDefaultAsync(C => C.CategoryId == id);
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return category;
        }
        public async Task<Category?> UpdateAsync(int id, UpdateCategoryRequestDto categoryRequestDto)
        {
            var existingCategory = await context.Categories.FirstOrDefaultAsync(C => C.CategoryId == id);
            if (existingCategory == null) return null;
            existingCategory.Name = categoryRequestDto.Name;
            existingCategory.Description = categoryRequestDto.Description;
            await context.SaveChangesAsync();
            return existingCategory;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var deletedCategory = await context.Categories.FirstOrDefaultAsync(C => C.CategoryId == id);
            if (deletedCategory == null) throw new Exception("No Such category found");
            // Check if there are any products related to this category
            var hasRelatedProducts = await context.Products
                .AnyAsync(p => p.CategoryId == deletedCategory.CategoryId);

            // If there are related products
            if (hasRelatedProducts)
            {
                return false;
            }
            if (!string.IsNullOrEmpty(deletedCategory.ImageUrl))
            {
                var publicId = GetPublicIdFromUrl(deletedCategory.ImageUrl); // Helper method to get public_id from Image URL
                var deletionParams = new DeletionParams(publicId)
                {
                    Invalidate = true
                };
                var result = _cloudinary.Destroy(deletionParams);
                if (result.Result != "ok")
                {
                    throw new Exception("Failed to delete image from Cloudinary.");
                }
            }

            context.Categories.Remove(deletedCategory);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> CategoryExists(int id)
        {
            return await context.Categories.AnyAsync(C => C.CategoryId == id);
        }
        public async Task<string> ImageUploadResult(IFormFile file)
        {
            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.FileName, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill")
                    };
                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                    if (uploadResult.Error != null)
                    {
                        throw new Exception(uploadResult.Error.Message);
                    }

                    return uploadResult.Url.ToString();
                }
            }

            throw new ArgumentException("Image file is empty.");
        }
        private string GetPublicIdFromUrl(string url)
        {
            var uri = new Uri(url);
            var segments = uri.Segments;
            var filename = Path.GetFileNameWithoutExtension(segments.Last());
            return filename;
        }
    }
}
