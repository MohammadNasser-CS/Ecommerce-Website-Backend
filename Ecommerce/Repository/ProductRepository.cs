using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Ecommerce.Data;
using Ecommerce.Dtos.Product;
using Ecommerce.Helpers;
using Ecommerce.Interfaces;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ecommerce.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceContext context;
        private readonly Cloudinary _cloudinary;
        private readonly ILogger<ProductRepository> logger;

        public ProductRepository(EcommerceContext context, Cloudinary cloudinary, ILogger<ProductRepository> logger)
        {
            this.context = context;
            _cloudinary = cloudinary;
            this.logger = logger;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            await context.Entry(product).Reference(p => p.Category).LoadAsync();
            return product;
        }

        public async Task<bool> ProductExists(int productId)
        {
            return await context.Products.AnyAsync(p => p.ProductId == productId);
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {

            return await context.Products.Include(p => p.Category)
                                                .FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<String> ImageUploadResult(IFormFile file)
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

        public async Task<List<Product>> GetAllAsync(ProductQueryObject productQuery)
        {
            var products = context.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(productQuery.Name))
            {
                products = products.Where(B => B.Name.Contains(productQuery.Name));
            }
            if (!string.IsNullOrWhiteSpace(productQuery.Category))
            {
                products = products.Where(B => B.Category.Name.Contains(productQuery.Category));
            }
            if (productQuery.Price != null)
            {
                products = products.Where(B => B.Price.Equals(productQuery.Price));
            }
            if (!string.IsNullOrWhiteSpace(productQuery.SortBy))
            {
                if (productQuery.SortBy == "Name")
                {
                    products = productQuery.IsDesc ? products.OrderByDescending(B => B.Name) : products.OrderBy(B => B.Name);

                }
                else if (productQuery.SortBy == "Description")
                {
                    products = productQuery.IsDesc ? products.OrderByDescending(B => B.Description) : products.OrderBy(B => B.Description);
                }
                else if (productQuery.SortBy == "Price")
                {
                    products = productQuery.IsDesc ? products.OrderByDescending(B => B.Price) : products.OrderBy(B => B.Price);
                }
            }
            int skipSize = (productQuery.PageNumber - 1) * productQuery.PageSize;
            return await products.Skip(skipSize).Take(productQuery.PageSize).ToListAsync();
        }

        public async Task<Product?> UpdateAsync(int id, UpdateProductRequestDto updateProduct)
        {
            var existingProduct = await context.Products.FirstOrDefaultAsync(B => B.ProductId == id);
            if (existingProduct == null) return null;
            existingProduct.Name = updateProduct.Name;
            existingProduct.Description = updateProduct.Description;
            existingProduct.Price = updateProduct.Price;
            existingProduct.Rating = updateProduct.Rating;
            existingProduct.CategoryId = updateProduct.CategoryId;
            existingProduct.TotalSales = updateProduct.TotalSales;
            existingProduct.ImageUrl = updateProduct.ImageUrl;
            await context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product?> DeleteAsyny(int id)
        {
            var deletedProduct = await context.Products.FirstOrDefaultAsync(B => B.ProductId == id);
            if (deletedProduct == null) return null;
            if (!string.IsNullOrEmpty(deletedProduct.ImageUrl))
            {
                var publicId = GetPublicIdFromUrl(deletedProduct.ImageUrl); // Helper method to get public_id from Image URL
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
            context.Products.Remove(deletedProduct);
            await context.SaveChangesAsync();
            return deletedProduct;
        }
        // Helper method to extract public ID from Cloudinary URL
        private string GetPublicIdFromUrl(string url)
        {
            var uri = new Uri(url);
            var segments = uri.Segments;
            var filename = Path.GetFileNameWithoutExtension(segments.Last());
            return filename;
        }
    }
}
