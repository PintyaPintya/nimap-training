using AutoMapper;
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
    private readonly IMapper _mapper;
    public ProductsController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        try
        {
            var products = await _context.Products.ToListAsync();

            var productDtos = _mapper.Map<List<ProductDto>>(products);

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

            var productDto = _mapper.Map<ProductDto>(product);

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

            var product = _mapper.Map<Product>(productCreateDto);

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

            _mapper.Map(productCreateDto, product);
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