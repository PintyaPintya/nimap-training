using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPractice.Data;
using WebApiPractice.Models;
using WebApiPractice.Validators;

namespace WebApiPractice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IValidator<Product> _validator;

    public ProductController(ApplicationDbContext context, IValidator<Product> validator)
    {
        _context = context;
        _validator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] Product product)
    {
        var validationResult = _validator.Validate(product);

        if (!validationResult.IsValid)
        {
            var errorResponse = validationResult.Errors.Select(e => new
            {
                Field = e.PropertyName,
                Error = e.ErrorMessage
            }
            );
            return BadRequest(new { Errors = errorResponse });
        }

        //if(!ModelState.IsValid) return BadRequest(ModelState);

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return Ok(product);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        if (product == null) return NotFound();

        return Ok(product);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
    {
        if (id != product.ProductId)
        {
            return BadRequest(new { Error = "Product ID in the URL does not match the Product ID in the body." });
        }

        var validationResult = _validator.Validate(product);
        if (!validationResult.IsValid)
        {
            var errorResponse = validationResult.Errors.Select(e => new
            {
                Field = e.PropertyName,
                Error = e.ErrorMessage
            });
            return BadRequest(errorResponse);
        }

        var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        if (existingProduct == null) return NotFound();

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.CategoryId = product.CategoryId;
        existingProduct.Stock = product.Stock;

        try
        {
            _context.Update(existingProduct);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = "An error occurred while updating the product.", Details = ex.Message });
        }
        return Ok(existingProduct);
    }
}