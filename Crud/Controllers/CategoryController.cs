using Crud.Models;
using Crud.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly int pageSize = 10;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int totalCategories = await _categoryRepository.GetCategoryCount();
            int totalPages = (int)Math.Ceiling((double)totalCategories / pageSize);

            if (page < 1)
            {
                page = 1;
            }
            else if (page > totalPages)
            {
                page = totalPages;
            }

            var categoryList = await _categoryRepository.GetIndexCategories(page, pageSize);

            if (categoryList == null)
            {
                categoryList = [];
            }

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;

            return View(categoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            bool ifCategoryExists = await _categoryRepository.CheckCategory(category);
            bool SaveComplete;

            if (!ifCategoryExists)
            {
                SaveComplete = await _categoryRepository.AddCategory(category);
            }
            else
            {
                ModelState.AddModelError("Name", "Category already exists");
                return View(category);
            }

            if (SaveComplete)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryRepository.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            bool ifCategoryExists = await _categoryRepository.CheckCategory(category);
            bool SaveComplete;

            if (!ifCategoryExists)
            {
                SaveComplete = await _categoryRepository.UpdateCategory(category);
            }
            else
            {
                ModelState.AddModelError("Name", "Category name already exists");
                return View(category);
            }

            if (SaveComplete)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        public async Task<IActionResult> Disable(int id)
        {
            var category = await _categoryRepository.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Disable(Category category)
        {
            var categoryToUpdate = await _categoryRepository.GetCategory(category.CategoryId);

            if (categoryToUpdate == null)
            {
                return NotFound();
            }

            if(categoryToUpdate.IsActive) 
                categoryToUpdate.IsActive = false;
            else
                categoryToUpdate.IsActive = true;

            bool SaveComplete = await _categoryRepository.UpdateCategory(categoryToUpdate);

            if (SaveComplete)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(categoryToUpdate);
            }
        }
    }
}
