using Ecommerce.Models;

namespace Ecommerce.IRepository;

public interface ICustomerRepository
{
    Task<ICollection<Customer>> GetAllActiveCustomers();
}