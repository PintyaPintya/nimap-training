using Ecommerce.Models;

namespace Ecommerce.IRepository;

public interface ICustomerRepository
{
    Task<ICollection<Customer>> GetAllActiveCustomers();
    Task<ICollection<Customer>> GetAllDisabledCustomers();
    Task<Customer?> GetCustomerById(int id);
    Task<bool> CheckIfCustomerExists(string name);
    Task AddCustomer(Customer customer);
    Task EditCustomer(Customer customer);
}