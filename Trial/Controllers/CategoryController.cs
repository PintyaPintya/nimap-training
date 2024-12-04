using Microsoft.AspNetCore.Mvc;
using Trial.IRepository;
using Trial.Mappers;
using Trial.Models;

namespace Trial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategories();
            
            if(categories == null) return NotFound();

            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);

            if (category == null)
                return Conflict("A category with this id doesn't exist.");

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryDto addCategoryDto)
        {
            var ifCategoryExists = await _categoryRepository.GetCategoryByNameAsync(addCategoryDto.Name);

            if(ifCategoryExists != null) 
                return Conflict("A category with this name already exists.");

            var category = addCategoryDto.ToCategory();
            await _categoryRepository.CreateAsync(category);

            return CreatedAtAction(nameof(GetAllCategories), new { id = category.Id }, category);
        }
    }
}