using Ecommerce.Data;
using Ecommerce.IRepository;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Customer>> GetAllActiveCustomers()
    {
        try
        {
            return await _context.Customers
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ICollection<Customer>> GetAllDisabledCustomers()
    {
        try
        {
            return await _context.Customers
                .Where(c => c.IsDeleted)
                .ToListAsync();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Customer?> GetCustomerById(int id)
    {
        try
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> CheckIfCustomerExists(string name)
    {
        try
        {
            return await _context.Customers
                .AnyAsync(c => c.Name.ToLower() == name.ToLower());
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task AddCustomer(Customer customer)
    {
        try
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task EditCustomer(Customer customer)
    {
        try
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}