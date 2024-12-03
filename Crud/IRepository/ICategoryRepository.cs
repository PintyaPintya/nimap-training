using Crud.Models;

public interface ICategoryRepository
{
    public Task<List<Category>> GetAllCategories();
    public Task<List<Category>> GetIndexCategories(int page, int pageSize);
    public Task<Category?> GetCategory(int id);
    public Task<bool> CheckCategory(Category category);
    public Task<bool> AddCategory(Category category);
    public Task<bool> UpdateCategory(Category category);
    public Task<int> GetCategoryCount();
}