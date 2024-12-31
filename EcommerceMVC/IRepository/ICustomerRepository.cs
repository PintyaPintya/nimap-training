using EcommerceMVC.Models;

namespace EcommerceMVC.IRepository;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAllActiveCustomers();
    Task<List<Customer>> GetAllDisabledCustomers();
    Task<Customer?> GetCustomerById(int id);
    Task<bool> CheckIfCustomerExists(string username);
    Task AddCustomer(Customer customer);
    Task UpdateCustomer(Customer customer);
}