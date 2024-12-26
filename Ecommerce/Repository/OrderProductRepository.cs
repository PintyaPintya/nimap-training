using Ecommerce.Data;
using Ecommerce.IRepository;
using Ecommerce.Models;

namespace Ecommerce.Repository;

public class OrderProductRepository : IOrderProductRepository
{
    private readonly ApplicationDbContext _context;

    public OrderProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddOrderDetails(List<OrderProduct> orderProducts)
    {
        try
        {
            await _context.OrderProducts.AddRangeAsync(orderProducts);
            await _context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}