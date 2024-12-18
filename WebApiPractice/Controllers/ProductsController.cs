using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiPractice.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(new[] {"Product 1", "Product 2", "Product 3"});
    }

    [HttpGet("public")]
    [AllowAnonymous]
    public IActionResult GetPublicProducts()
    {
        return Ok(new[] { "Public Product 1", "Public Product 2" });
    }

    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAdminProducts()
    {
        return Ok(new[] { "Admin Product 1", "Admin Product 2" });
    }
}
