using Ecommerce.Data;
using Ecommerce.IRepository;
using Ecommerce.Models;

namespace Ecommerce.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;
    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddOrder(Order order)
    {
        try
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}