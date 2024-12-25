using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.IRepository;

public interface IProductRepository
{
    Task<ICollection<Product>> GetAllProducts();
    Task<ICollection<Product>> GetAllDisabledProducts();
    Task<Product?> GetProductById(int id);
    Task AddProduct(Product product);
    Task<bool> CheckIfProductNameExists(string name);
    Task EditProduct(Product product);
}
