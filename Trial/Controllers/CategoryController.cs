using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Trial.IRepository;
using Trial.Mappers;
using Trial.Models;
using Trial.Models.Entities;

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
            try
            {
                var categories = await _categoryRepository.GetAllCategories();
                if (categories == null || categories.Count == 0)
                    return NotFound("No active categories found.");

                if (categories == null) return NotFound();

                return Ok(categories);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while fetching categories.");
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);

            if (category == null)
                return NotFound($"Category with ID {id} not found.");

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryDto addCategoryDto)
        {
            try
            {
                var ifCategoryExists = await _categoryRepository.CheckCategoryByNameAsync(addCategoryDto.Name);

                if (ifCategoryExists != null)
                    return BadRequest($"Category with the name '{addCategoryDto.Name}' already exists.");

                var category = addCategoryDto.ToCategory();
                await _categoryRepository.CreateAsync(category);

                return CreatedAtAction(nameof(GetAllCategories), new { id = category.Id }, category);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while creating category.");
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                var ifCategoryExists = await _categoryRepository.CheckCategoryByNameAsync(updateCategoryDto.Name);
                if (ifCategoryExists != null)
                    return BadRequest($"Category with the name '{updateCategoryDto.Name}' already exists.");

                var category = await _categoryRepository.GetCategoryByIdAsync(id);

                if (category == null)
                    return NotFound($"Category with ID {id} not found.");

                await _categoryRepository.UpdateAsync(category, updateCategoryDto);
                return Ok(category);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating category.");
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DisableCategory(int id)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryByIdAsync(id);

                if (category == null)
                    return NotFound($"Category with ID {id} not found.");

                await _categoryRepository.DisableAsync(category);
                return Ok(category);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting the product.");
            }
        }       
    }
}