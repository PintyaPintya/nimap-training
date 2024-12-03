using Crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly int pageSize = 10;

        public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int totalProducts = await _productRepository.GetProductCount();
            int totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            if (page < 1)
            {
                page = 1;
            }
            else if (page > totalPages)
            {
                page = totalPages;
            }

            var productList = await _productRepository.GetProducts(page, pageSize);

            if (productList == null)
            {
                productList = [];
            }

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;

            return View(productList);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryRepository.GetAllCategories();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            bool ifProductExists = await _productRepository.CheckProduct(product);
            bool SaveComplete;

            if (!ifProductExists)
            {
                SaveComplete = await _productRepository.AddProduct(product);
            }
            else
            {
                ModelState.AddModelError("Name", "Product already exists");
                return View(product);
            }

            if (SaveComplete)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetProduct(id);
            ViewBag.Categories = await _categoryRepository.GetAllCategories();

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            bool ifProductExists = await _productRepository.CheckProduct(product);
            bool SaveComplete;

            if (!ifProductExists)
            {
                SaveComplete = await _productRepository.UpdateProduct(product);
            }
            else
            {
                ModelState.AddModelError("Name", "Product name already exists");
                return View(product);
            }

            if (SaveComplete)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            bool SaveComplete;

            SaveComplete = await _productRepository.DeleteProduct(product);

            if (SaveComplete)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
    }
}
