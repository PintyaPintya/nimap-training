using Trial.Models;
using Trial.Models.Entities;

namespace Trial.IRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllActiveProducts();
        Task CreateAsync(Product product);
        Task<Product?> CheckProductByName(AddOrUpdateProductDto addProductDto);
        Task<Product?> GetProductById(int id);
        Task UpdateAsync(Product product, AddOrUpdateProductDto addOrUpdateProductDto);
        Task DeleteAsync(Product product);
    }
}
