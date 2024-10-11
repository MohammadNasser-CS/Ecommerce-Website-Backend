using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Ecommerce.Data;
using Ecommerce.Dtos.Product;
using Ecommerce.Helpers;
using Ecommerce.Interfaces;
using Ecommerce.Mapper;
using Ecommerce.Models;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductRepository productRepository;

        public ProductController(EcommerceContext context, ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _context = context;
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductQueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = ModelState });
            var totalProducts = await productRepository.CountAsync(query);
            var products = await productRepository.GetAllAsync(query);
            if (products.Count > 0)
            {
                var productDtos = products.Select(P => P.ToProductDto());
                var totalPages = (int)Math.Ceiling((double)totalProducts / query.PageSize);

                return Ok(new
                {
                    Message = "success",
                    currentPage = query.PageNumber,
                    totalPages = totalPages,
                    products = productDtos
                });
            }
            return NotFound(new { Error = "No products found" });
        }

        // GET: api/Product/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = ModelState });
            var product = await productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { Error = "No Such product found" });
            }

            return Ok(new { Message = "success", product = product.ToProductDto() });

        }
        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductRequestDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Error = ModelState });
            }
            if (!await categoryRepository.CategoryExists(productDto.CategoryId))
            {
                return BadRequest(new { Error = "Category Does Not Exist" });
            }
            string imageUrl;
            try
            {
                imageUrl = await productRepository.ImageUploadResult(productDto.Image);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            var product = productDto.CreateProductDto(imageUrl);

            await productRepository.CreateProductAsync(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, new { Message = "success", product = product.ToProductDto() });
        }

        // PUT: api/Product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequestDto updateProductRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = ModelState });
            var product = await productRepository.GetProductByIdAsync(id);
            if (product == null)
                return NotFound(new { Error = "No such product found" });
            product.UpdateProduct(updateProductRequest);
            await productRepository.UpdateAsync(product);
            return Ok(new { Message = "success", product = product.ToProductDto() });
        }

        // DELETE: api/Product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = ModelState });
            var productModel = await productRepository.DeleteAsyny(id);
            if (productModel == null) return NotFound(new { Error = "No Such product found" });
            return NoContent();
        }
    }
}
