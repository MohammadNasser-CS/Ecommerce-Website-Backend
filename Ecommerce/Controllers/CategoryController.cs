using Ecommerce.Data;
using Ecommerce.Dtos.Category;
using Ecommerce.Interfaces;
using Ecommerce.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(EcommerceContext context, ICategoryRepository categoryRepository)
        {
            _context = context;
            this._categoryRepository = categoryRepository;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoryDtos = categories.Select(C => C.ToCategoryDto()).ToList();
            return Ok(new { message = "success", categories = categoryDtos });
        }

        // GET: api/Category/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDto = CategoryMapper.ToCategoryDto(category);
            return Ok(new { message = "success", category = categoryDto });
        }

        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] CreateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string imageUrl;
            try
            {
                imageUrl = await _categoryRepository.ImageUploadResult(categoryDto.Image);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            var category = categoryDto.CreateCategoryDto(imageUrl);

            await _categoryRepository.CreateAsync(category);

            return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, new { message = "success", category = category.ToCategoryDto() });
        }

        // PUT: api/Category/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryRequestDto updateCategory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var category = await _categoryRepository.UpdateAsync(id, updateCategory);
            if (category == null) return NotFound();
            updateCategory.UpdateCategoryDto(category);
            return Ok(new { message = "success", category = updateCategory });
        }

        // DELETE: api/Category/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var success = await _categoryRepository.DeleteAsync(id);

                if (!success)
                {
                    return BadRequest(new { message = "Cannot delete this category as there are products associated with it." });
                }

                return Ok(new { message = "Category deleted successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
