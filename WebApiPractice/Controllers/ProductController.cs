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
    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
    {
        ProductDtoValidator _validator = new ProductDtoValidator(_context);

        var validationResult = await _validator.ValidateAsync(productDto);

        if (!validationResult.IsValid)
        {
            var errorResponse = validationResult.Errors.Select(e => new
            {
                Field = e.PropertyName,
                Error = e.ErrorMessage
            });
            return BadRequest(new { Errors = errorResponse });
        }

        var product = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            CategoryId = productDto.CategoryId,
            Discount = productDto.Discount,
            Description = productDto.Description,
        };

        await _context.AddAsync(product);
        await _context.SaveChangesAsync();

        return Ok(product);
    }
}