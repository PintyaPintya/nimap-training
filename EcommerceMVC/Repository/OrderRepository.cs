using EcommerceMVC.Data;
using EcommerceMVC.IRepository;
using EcommerceMVC.Models;
using EcommerceMVC.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;
    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<DisplayOrderDto>> GetAllPendingOrders()
    {
        try
        {
            return await _context.Orders
                .Where(o => !o.IsDeleted && o.Status == "Pending")
                .Include(o => o.Customer)
                .Include(o => o.Products)
                    .ThenInclude(op => op.Product)
                .Select(o => new DisplayOrderDto
                {
                    Order = o,
                    ProductNames = o.Products.Select(op => op.Product.Name).ToList()
                })
                .ToListAsync();
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException?.Message;
            throw new Exception($"Error: {ex.Message}. Inner Exception: {innerExceptionMessage}");
        }
    }

    public async Task<List<DisplayOrderDto>> GetAllCompletedOrders()
    {
        try
        {
            return await _context.Orders
                .Where(o => !o.IsDeleted && o.Status == "Completed")
                .Include(o => o.Customer)
                .Include(o => o.Products)
                    .ThenInclude(op => op.Product)
                .Select(o => new DisplayOrderDto
                {
                    Order = o,
                    ProductNames = o.Products.Select(op => op.Product.Name).ToList()
                })
                .ToListAsync();
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException?.Message;
            throw new Exception($"Error: {ex.Message}. Inner Exception: {innerExceptionMessage}");
        }
    }
}