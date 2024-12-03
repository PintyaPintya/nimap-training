using Crud.Data;
using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<List<Category>> GetIndexCategories(int page, int pageSize)
        {
            return await _context.Categories
                        .OrderBy(p => p.CategoryId)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        }

        public async Task<int> GetCategoryCount()
        {
            return await _context.Categories
                         .Where(c => c.IsActive)
                         .CountAsync();
        }
        public async Task<Category?> GetCategory(int id)
        {
            return await _context.Categories
                            .SingleOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<bool> CheckCategory(Category category)
        {
            if(category == null) return true;

            return await _context.Categories
                .AnyAsync(c => c.Name.ToLower() == category.Name.ToLower());
        }

        public async Task<bool> AddCategory(Category category)
        {
            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            try
            {
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
