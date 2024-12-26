using Ecommerce.Models;

namespace Ecommerce.IRepository;

public interface IOrderProductRepository
{
    Task AddOrderDetails(List<OrderProduct> orderProducts);
}