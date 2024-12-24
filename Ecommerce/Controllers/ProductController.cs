using Ecommerce.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return Ok(products);
        }
    }
}
