using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPractice.Data;
using WebApiPractice.Models;

namespace WebApiPractice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        try
        {
            var products = await _context.Products.ToListAsync();

            var productDtos = new List<ProductDto>();
            foreach (var product in products)
            {
                var productDto = new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    IsAvailable = product.IsAvailable,
                    Category = product.Category
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

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetProductById(int id)
    {
        try
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            var productDto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                IsAvailable = product.IsAvailable,
                Category = product.Category
            };
            return Ok(productDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while retrieving the product.", Details = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<ProductCreateDto>> AddProduct(ProductCreateDto productCreateDto)
    {
        try
        {
            if (productCreateDto == null) return BadRequest("Invalid product data");

            var product = new Product()
            {
                Name = productCreateDto.Name,
                Description = productCreateDto.Description,
                Price = productCreateDto.Price,
                Category = productCreateDto.Category,
                SupplierCost = productCreateDto.SupplierCost,
                SupplierInfo = productCreateDto.SupplierInfo,
                StockQuantity = productCreateDto.StockQuantity,
                IsAvailable = productCreateDto.StockQuantity > 0
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return Ok(productCreateDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while retrieving the product.", Details = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ProductCreateDto>> UpdateProduct(ProductCreateDto productCreateDto, int id)
    {
        try
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            if (productCreateDto == null) return BadRequest("Invalid product data");

            product.Name = productCreateDto.Name;
            product.Description = productCreateDto.Description;
            product.Price = productCreateDto.Price;
            product.Category = productCreateDto.Category;
            product.SupplierCost = productCreateDto.SupplierCost;
            product.SupplierInfo = productCreateDto.SupplierInfo;
            product.StockQuantity = productCreateDto.StockQuantity;
            product.IsAvailable = productCreateDto.StockQuantity > 0;

            await _context.SaveChangesAsync();

            return Ok(productCreateDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while retrieving the product.", Details = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> RemoveProduct(int id)
    {
        try
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while retrieving the product.", Details = ex.Message });
        }
    }
}