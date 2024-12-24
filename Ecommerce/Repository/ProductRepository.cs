using Ecommerce.Data;
using Ecommerce.IRepository;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ICollection<Product>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }
}
