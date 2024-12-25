using Ecommerce.IRepository;
using Ecommerce.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet("/api/customers")]
    public async Task<ActionResult<List<CustomerDto>>> GetActiveCustomers()
    {
        try
        {
            var customers = await _customerRepository.GetAllActiveCustomers();
            
            if(customers.Count < 1) return Ok("No active customers");

            var customerDtos = new List<CustomerDto>();
            foreach(var customer in customers)
            {
                var customerDto = new CustomerDto()
                {
                    Name = customer.Name,
                    Email = customer.Email,
                    Address = customer.Address
                };
                customerDtos.Add(customerDto);
            }

            return Ok(customerDtos);
        }
        catch(Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while retrieving active customers.", Details = ex.Message });
        }
    }
}

