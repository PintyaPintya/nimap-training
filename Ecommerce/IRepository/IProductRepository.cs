using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.IRepository;

public interface IProductRepository
{
    Task<ICollection<Product>> GetAllProducts();
}
