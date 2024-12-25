using Ecommerce.IRepository;
using Ecommerce.Models;
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

            if (customers.Count < 1) return Ok("No active customers");

            var customerDtos = new List<CustomerDto>();
            foreach (var customer in customers)
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
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while retrieving active customers.", Details = ex.Message });
        }
    }

    [HttpGet("/api/disabled-customers")]
    public async Task<ActionResult<List<CustomerDto>>> GetAllDisabledCustomers()
    {
        try
        {
            var customers = await _customerRepository.GetAllDisabledCustomers();

            if (customers.Count < 1) return Ok("No disabled customers");

            var customerDtos = new List<CustomerDto>();
            foreach (var customer in customers)
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
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occured while retrieving disabled customers", Details = ex.Message });
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
    {
        try
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null) return NotFound($"No customer found with ID: {id}");

            var customerDto = new CustomerDto()
            {
                Name = customer.Name,
                Email = customer.Email,
                Address = customer.Address
            };

            return Ok(customerDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occured while retriving customer", Details = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddCustomer(CustomerDto customerDto)
    {
        try
        {
            bool customerExists = await _customerRepository.CheckIfCustomerExists(customerDto.Name);
            if (customerExists) return BadRequest("Customer already exists");

            var customer = new Customer()
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                Address = customerDto.Address,
                IsDeleted = false
            };

            await _customerRepository.AddCustomer(customer);
            return Ok(customerDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occured while adding customer", Details = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> EditCustomer(int id, EditCustomerDto editCustomerDto)
    {
        try
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if(customer == null) return NotFound($"Customer not found with ID: {id}");

            if(!string.Equals(editCustomerDto.Name, customer.Name, StringComparison.OrdinalIgnoreCase))
            {
                bool customerExists = await _customerRepository.CheckIfCustomerExists(editCustomerDto.Name);
                if(customerExists) return BadRequest("Customer with this name already exists");
            }

            customer.Name = editCustomerDto.Name;
            customer.Email = editCustomerDto.Email;
            customer.Address = editCustomerDto.Address;
            customer.IsDeleted = editCustomerDto.IsDeleted;

            await _customerRepository.EditCustomer(customer);
            return Ok(editCustomerDto);
        }
        catch(Exception ex)
        {
            return StatusCode(500, new {Message = "An error occured while editing customer", Details = ex.Message});
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> RemoveCustomer(int id)
    {
        try
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if(customer == null) return NotFound($"Customer not found with ID: {id}");

            customer.IsDeleted = true;

            await _customerRepository.EditCustomer(customer);
            return NoContent();
        }
        catch(Exception ex)
        {
            return StatusCode(500, new {Message = "An error occured while deleting customer", Details = ex.Message});
        }
    }
}

