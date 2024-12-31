using EcommerceMVC.Data;
using EcommerceMVC.IRepository;
using EcommerceMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;
    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllActiveCustomers()
    {
        try
        {
            return await _context.Customers
                .Where(c => !c.IsDeleted).ToListAsync();
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException?.Message;
            throw new Exception($"Error: {ex.Message}. Inner Exception: {innerExceptionMessage}");
        }
    }

    public async Task<Customer?> GetCustomerById(int id)
    {
        try
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException?.Message;
            throw new Exception($"Error: {ex.Message}. Inner Exception: {innerExceptionMessage}");
        }
    }

    public async Task<bool> CheckIfCustomerExists(string username)
    {
        try
        {
            return await _context.Customers
                .AnyAsync(p => p.Username.ToLower() == username.ToLower());
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException?.Message;
            throw new Exception($"Error: {ex.Message}. Inner Exception: {innerExceptionMessage}");
        }
    }

    public async Task AddCustomer(Customer customer)
    {
        try
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException?.Message;
            throw new Exception($"Error: {ex.Message}. Inner Exception: {innerExceptionMessage}");
        }
    }

    public async Task UpdateCustomer(Customer customer)
    {
        try
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException?.Message;
            throw new Exception($"Error: {ex.Message}. Inner Exception: {innerExceptionMessage}");
        }
    }

    public async Task<List<Customer>> GetAllDisabledCustomers()
    {
        try
        {
            return await _context.Customers
                .Where(c => c.IsDeleted).ToListAsync();
        }
        catch (Exception ex)
        {
            var innerExceptionMessage = ex.InnerException?.Message;
            throw new Exception($"Error: {ex.Message}. Inner Exception: {innerExceptionMessage}");
        }
    }
}