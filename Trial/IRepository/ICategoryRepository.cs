using Trial.Models;
using Trial.Models.Entities;

namespace Trial.IRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category, UpdateCategoryDto updateCategoryDto);
        Task DisableAsync(Category category);
        Task<Category?> CheckCategoryByNameAsync(string name);
        Task<Category?> GetCategoryByIdAsync(int id);
    }
}