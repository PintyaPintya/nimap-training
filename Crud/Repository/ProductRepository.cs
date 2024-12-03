using Crud.Data;
using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts(int page, int pageSize)
        {
            return await _context.Products
                        .OrderBy(p => p.ProductId)
                        .Include(p => p.Category)
                        .Where(p => p.Category.IsActive == true)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        }

        public async Task<int> GetProductCount()
        {
            return await _context.Products
                         .Where(p => p.Category.IsActive)
                         .CountAsync();
        }
        public async Task<bool> CheckProduct(Product product)
        {
            if (product == null) return true;

            bool productExists = await _context.Products
                .AnyAsync(p => p.Name.ToLower() == product.Name.ToLower() 
                && p.CategoryId == product.CategoryId);

            return productExists;
        }

        public async Task<bool> AddProduct(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<Product?> GetProduct(int id)
        {
            return await _context.Products
                            .SingleOrDefaultAsync(c => c.ProductId == id);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
