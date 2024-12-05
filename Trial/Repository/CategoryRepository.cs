using Microsoft.EntityFrameworkCore;
using Trial.Data;
using Trial.IRepository;
using Trial.Models;
using Trial.Models.Entities;

namespace Trial.Repository
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
            try
            {
                return await _context.Categories.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving categories", ex);
            }
        }

        public async Task CreateAsync(Category category)
        {
            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating category", ex);

            }
        }
        public async Task UpdateAsync(Category category, UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                category.Name = updateCategoryDto.Name;
                await _context.SaveChangesAsync();
                return;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating category", ex);
            }
        }

        public async Task DisableAsync(Category category)
        {
            try
            {
                if (category.IsActive)
                    category.IsActive = false;
                else
                    category.IsActive = true;

                await _context.SaveChangesAsync();
                return;
            }
            catch (Exception ex)
            {
                throw new Exception("Error disabling/enabling product", ex);
            }
        }

        public async Task<Category?> CheckCategoryByNameAsync(string name)
        {
            try
            {
                return await _context.Categories
                    .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
            }
            catch (Exception ex)
            {
                throw new Exception("Error while verifying category name", ex);
            }
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            try
            {
                return await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting category by id", ex);
            }
        }
    }
}