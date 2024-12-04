using Trial.Models;
using Trial.Models.Entities;

namespace Trial.IRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task CreateAsync(Category category);
        Task<Category?> GetCategoryByNameAsync(string name);
        Task<Category?> GetCategoryByIdAsync(int id);
    }
}