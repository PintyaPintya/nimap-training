using EcommerceMVC.Models;

namespace EcommerceMVC.IRepository;

public interface IProductRepository
{
    Task<List<Product>> GetAllActiveProducts();
    Task<List<Product>> GetAllDisabledProducts();
    Task<bool> CheckIfProductExists(string name);
    Task<Product?> GetProductById(int id);
    Task AddProduct(Product product);
    Task UpdateProduct(Product product);
}