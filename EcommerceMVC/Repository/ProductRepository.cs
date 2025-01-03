using EcommerceMVC.Data;
using EcommerceMVC.IRepository;
using EcommerceMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllActiveProducts()
    {
        try
        {
            return await _context.Products
                .Where(p => !p.IsDeleted).ToListAsync();
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException?.Message;
            throw new Exception($"Error: {ex.Message}. Inner Exception: {innerExceptionMessage}");
        }
    }

    public async Task<List<Product>> GetAllDisabledProducts()
    {
        try
        {
            return await _context.Products
                .Where(p => p.IsDeleted).ToListAsync();
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException?.Message;
            throw new Exception($"Error: {ex.Message}. Inner Exception: {innerExceptionMessage}");
        }
    }

    public async Task<bool> CheckIfProductExists(string name)
    {
        try
        {
            return await _context.Products
                .AnyAsync(p => p.Name.ToLower() == name.ToLower());
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException?.Message;
            throw new Exception($"Error: {ex.Message}. Inner Exception: {innerExceptionMessage}");
        }
    }

    public async Task<Product?> GetProductById(int id)
    {
        try
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException?.Message;
            throw new Exception($"Error: {ex.Message}. Inner Exception: {innerExceptionMessage}");
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
            var innerExceptionMessage = ex.InnerException?.Message;
            throw new Exception($"Error: {ex.Message}. Inner Exception: {innerExceptionMessage}");
        }
    }

    public async Task UpdateProduct(Product product)
    {
        try
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException?.Message;
            throw new Exception($"Error: {ex.Message}. Inner Exception: {innerExceptionMessage}");
        }
    }
}