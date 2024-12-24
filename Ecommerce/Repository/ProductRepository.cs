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
        try
        {
            return await _context.Products
                        .Where(p => !p.IsDeleted)
                        .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving the products " + ex.Message);
        }

    }

    public async Task<Product?> GetProductById(int id)
    {
        try
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving the product with Id: {id}" + ex.Message);
        }
    }

    public async Task<bool> CheckIfProductNameExists(string name)
    {
        try
        {
            return await _context.Products
                .AnyAsync(p => p.Name.ToLower() == name.ToLower());
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while checking the product name: " + ex.Message);
        }
    }

    public async Task AddProduct(Product product)
    {
        try
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while adding the product: " + ex.Message);
        }
    }

    public async Task EditProduct(Product product)
    {
        try
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while editing the product: " + ex.Message);
        }
    }

    public async Task RemoveProduct(Product product)
    {
        try
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while removing the product: " + ex.Message);
        }
    }
}
