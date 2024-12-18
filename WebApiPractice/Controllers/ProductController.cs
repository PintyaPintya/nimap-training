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
    public async Task<IActionResult> AddProduct([FromBody] Product product)
    {        
        if(!ModelState.IsValid) return BadRequest(ModelState);

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return Ok(product);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        if(product == null) return NotFound();

        return Ok(product);
    }
}