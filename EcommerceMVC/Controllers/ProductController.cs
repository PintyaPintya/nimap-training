using EcommerceMVC.IRepository;
using EcommerceMVC.Models;
using EcommerceMVC.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet("/products")]
    public async Task<IActionResult> Index()
    {
        try
        {
            var products = await _productRepository.GetAllActiveProducts();

            if (products == null)
            {
                products = [];
            }

            return View(products);
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    [HttpGet("/disabled-products")]
    public async Task<IActionResult> DisabledProducts()
    {
        try
        {
            var products = await _productRepository.GetAllDisabledProducts();

            if (products == null)
            {
                products = [];
            }

            return View("Disabled", products);
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    [HttpGet("/product/{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        try
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null) return NotFound();

            CreateProductDto createProductDto = new CreateProductDto()
            {
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                Description = product.Description
            };

            return View("Product", createProductDto);
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto createProductDto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                bool productExists = await _productRepository.CheckIfProductExists(createProductDto.Name);
                if (productExists)
                {
                    ModelState.AddModelError("Name", "Product already exists");
                    return View(createProductDto);
                }

                Product product = new Product
                {
                    Name = createProductDto.Name,
                    Price = createProductDto.Price,
                    Quantity = createProductDto.Quantity,
                    Description = createProductDto.Description,
                    IsDeleted = false
                };

                await _productRepository.AddProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(createProductDto);
            }
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    public async Task<IActionResult> Edit(int id)
    {
        try
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null) return NotFound();

            return View(product);
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var productFromDb = await _productRepository.GetProductById(product.Id);
                if (productFromDb == null) return NotFound();

                if (productFromDb.Name != product.Name)
                {
                    bool productExists = await _productRepository.CheckIfProductExists(product.Name);
                    if (productExists)
                    {
                        ModelState.AddModelError("Name", "Product already exists");
                        return View(product);
                    }
                }

                productFromDb.Quantity = product.Quantity;
                productFromDb.Description = product.Description;
                productFromDb.Name = product.Name;
                productFromDb.Price = product.Price;

                await _productRepository.UpdateProduct(productFromDb);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null) return NotFound();

            return View(product);
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Product product)
    {
        try
        {
            product.IsDeleted = true;
            await _productRepository.UpdateProduct(product);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    public async Task<IActionResult> RestoreProduct(int id)
    {
        try
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null) return NotFound();

            product.IsDeleted = false;
            await _productRepository.UpdateProduct(product);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }
}