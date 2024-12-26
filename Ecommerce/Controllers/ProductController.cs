using Ecommerce.IRepository;
using Ecommerce.Models;
using Ecommerce.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet("/api/products")]
    [AllowAnonymous]
    public async Task<ActionResult<List<ProductDto>>> GetAllActiveProducts()
    {
        try
        {
            var products = await _productRepository.GetAllProducts();

            if(products.Count < 1) return Ok("No products are listed yet");

            var productDtos = new List<ProductDto>();
            foreach (var product in products)
            {
                var productDto = new ProductDto()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description
                };
                productDtos.Add(productDto);
            }

            return Ok(productDtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while retrieving products.", Details = ex.Message });
        }
    }

    [HttpGet("/api/disabled-products")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<ProductDto>>> GetAllDisabledProducts()
    {
        try
        {
            var products = await _productRepository.GetAllDisabledProducts();

            if(products.Count < 1) return Ok("No disabled products");

            var productDtos = new List<ProductDto>();
            foreach (var product in products)
            {
                var productDto = new ProductDto()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description
                };
                productDtos.Add(productDto);
            }

            return Ok(productDtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while retrieving disabled products.", Details = ex.Message });
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetProductById(int id)
    {
        try
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null || product.IsDeleted) return NotFound($"Product with Id: {id} does not exist");

            var productDto = new ProductDto()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };

            return Ok(productDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = $"An error occurred while retrieving the product with Id: {id}", Details = ex.Message });
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> AddProduct(CreateProductDto createProductDto)
    {
        try
        {
            bool productNameExists = await _productRepository.CheckIfProductNameExists(createProductDto.Name);
            if (productNameExists) return BadRequest("Product already exists");

            var product = new Product()
            {
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                Quantity = createProductDto.Quantity,
                Description = createProductDto.Description,
                IsDeleted = false,
                Orders = new List<OrderProduct>()
            };
            await _productRepository.AddProduct(product);
            return Ok(createProductDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while adding the product", Details = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> EditProduct(int id, EditProductDto editProductDto)
    {
        try
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null) return NotFound($"Product with Id: {id} does not exist");

            // only checks if product name exists if the product name is changed
            if (!string.Equals(editProductDto.Name, product.Name, StringComparison.OrdinalIgnoreCase))
            {
                bool productNameExists = await _productRepository.CheckIfProductNameExists(editProductDto.Name);
                if (productNameExists) return BadRequest("Product with this name already exists");
            }

            product.Name = editProductDto.Name;
            product.Price = editProductDto.Price;
            product.Quantity = editProductDto.Quantity;
            product.Description = editProductDto.Description;
            product.IsDeleted = editProductDto.IsDeleted;

            await _productRepository.EditProduct(product);
            return Ok(editProductDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while editing the product", Details = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        try
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null) return NotFound($"Product with Id: {id} does not exist");

            product.IsDeleted = true;

            await _productRepository.EditProduct(product);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while removing the product", Details = ex.Message });
        }
    }
}
