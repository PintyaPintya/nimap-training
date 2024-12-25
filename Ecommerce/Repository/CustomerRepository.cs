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
            throw new Exception($"An error occurred while retrieving active customers " + ex.Message);
        }
    }
}