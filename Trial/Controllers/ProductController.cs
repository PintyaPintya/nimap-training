using Microsoft.AspNetCore.Mvc;
using Trial.IRepository;
using Trial.Mappers;
using Trial.Models;

namespace Trial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productRepository.GetAllActiveProducts();

                if (products == null || products.Count == 0)
                    return NotFound("No active products found.");

                return Ok(products);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while fetching the products.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddOrUpdateProductDto addOrUpdateProductDto)
        {
            try
            {
                var ifCategoryExists = await _categoryRepository.GetCategoryByIdAsync(addOrUpdateProductDto.CategoryId);
                if (ifCategoryExists == null)
                    return NotFound($"Category with ID {addOrUpdateProductDto.CategoryId} not found.");

                var ifProductExists = await _productRepository.CheckProductByName(addOrUpdateProductDto);
                if (ifProductExists != null)
                    return BadRequest($"Product with the name '{addOrUpdateProductDto.Name}' already exists in this category.");

                var product = addOrUpdateProductDto.ToProduct();
                await _productRepository.CreateAsync(product);
                return CreatedAtAction(nameof(GetAllProducts), new { id = product.Id }, product);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while creating the product.");
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, AddOrUpdateProductDto addOrUpdateProductDto)
        {
            try
            {
                var ifCategoryExists = await _categoryRepository.GetCategoryByIdAsync(addOrUpdateProductDto.CategoryId);
                if (ifCategoryExists == null)
                    return NotFound($"Category with ID {addOrUpdateProductDto.CategoryId} not found.");

                var ifProductExists = await _productRepository.CheckProductByName(addOrUpdateProductDto);
                if (ifProductExists != null)
                    return BadRequest($"Product with the name '{addOrUpdateProductDto.Name}' already exists in this category.");

                var product = await _productRepository.GetProductById(id);
                if (product == null)
                    return NotFound($"Product with ID {id} not found.");

                await _productRepository.UpdateAsync(product, addOrUpdateProductDto);
                return CreatedAtAction(nameof(GetAllProducts), new { id = product.Id }, product);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the product.");
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _productRepository.GetProductById(id);
                if (product == null)
                    return NotFound($"Product with ID {id} not found.");

                await _productRepository.DeleteAsync(product);
                return Ok($"Product with ID {id} has been deleted.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting the product.");
            }
        }
    }
}
