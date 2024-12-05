using Microsoft.EntityFrameworkCore;
using Trial.Data;
using Trial.IRepository;
using Trial.Models;
using Trial.Models.Entities;

namespace Trial.Repository
{
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
                    .Where(p => p.Category.IsActive)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving active products", ex);
            }
        }

        public async Task CreateAsync(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating product", ex);
            }
        }

        public async Task UpdateAsync(Product product, AddOrUpdateProductDto addOrUpdateProductDto)
        {
            try
            {
                product.Name = addOrUpdateProductDto.Name;
                product.CategoryId = addOrUpdateProductDto.CategoryId;
                await _context.SaveChangesAsync();
                return;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product", ex);
            }
        }

        public async Task DeleteAsync(Product product)
        {
            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting product", ex);
            }
        }

        public async Task<Product?> CheckProductByName(AddOrUpdateProductDto addProductDto)
        {
            try
            {
                return await _context.Products
                    .FirstOrDefaultAsync(c => c.Name.ToLower() == addProductDto.Name.ToLower()
                        && c.CategoryId == addProductDto.CategoryId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while verifying product name", ex);
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
                throw new Exception("Error getting product by id", ex);
            }
        }
    }
}
