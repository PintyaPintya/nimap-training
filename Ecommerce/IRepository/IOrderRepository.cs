namespace Ecommerce.IRepository;

using Ecommerce.Models;

public interface IOrderRepository
{
    Task AddOrder(Order order);
    Task AddOrderDetails(List<OrderProduct> orderProducts);
    Task<List<Order>> GetPendingOrders();
    Task<List<Order>> GetCompletedOrders();
    Task<Order?> GetPendingOrderById(int id);
    Task EditOrderStatus(Order order);
    Task CancelOrder(Order order);
}