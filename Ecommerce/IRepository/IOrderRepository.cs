namespace Ecommerce.IRepository;

using Ecommerce.Models;

public interface IOrderRepository
{
    Task AddOrder(Order order);
}