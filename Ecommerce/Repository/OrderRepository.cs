using Ecommerce.Data;
using Ecommerce.IRepository;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IProductRepository _productRepository;
    public OrderRepository(ApplicationDbContext context, IProductRepository productRepository)
    {
        _context = context;
        _productRepository = productRepository;
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

    public async Task<List<Order>> GetPendingOrders()
    {
        try
        {
            return await _context.Orders
                .Where(p => p.Status == "Pending" && !p.IsDeleted)
                .ToListAsync();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<Order>> GetCompletedOrders()
    {
        try
        {
            return await _context.Orders
                .Where(p => p.Status == "Completed")
                .ToListAsync();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Order?> GetPendingOrderById(int id)
    {
        try
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task EditOrderStatus(Order order)
    {
        try
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task CancelOrder(Order order)
    {
        try
        {            
            var orderProducts = _context.OrderProducts.Where(o => o.OrderId == order.Id);
            var productIds = orderProducts.Select(p => p.ProductId).ToList();
            var products = await _productRepository.GetProductByListOfId(productIds);

            foreach(var orderProduct in orderProducts)
            {
                var requiredProduct = products.Find(p => p.Id == orderProduct.ProductId);
                requiredProduct.Quantity += orderProduct.Quantity;
            }

            _context.Orders.Update(order);
            _context.OrderProducts.RemoveRange(orderProducts);
            _context.Products.UpdateRange(products);

            await _context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}