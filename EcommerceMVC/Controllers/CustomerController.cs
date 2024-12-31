using EcommerceMVC.IRepository;
using EcommerceMVC.Models;
using EcommerceMVC.Models.Dto;
using EcommerceMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EcommerceMVC.Controllers;

public class CustomerController : Controller
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet("/customers")]
    public async Task<IActionResult> Index()
    {
        try
        {
            var customers = await _customerRepository.GetAllActiveCustomers();
            if (customers == null) return NotFound();

            return View(customers);
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    [HttpGet("/customer/{id:int}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        try
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null) return NotFound();

            CustomerDto customerDto = new CustomerDto()
            {
                Username = customer.Username,
                Name = customer.Name,
                Role = customer.Role,
                Email = customer.Email,
                Address = customer.Address
            };
            return View("Customer", customerDto);
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CustomerDto customerDto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                bool customerExists = await _customerRepository.CheckIfCustomerExists(customerDto.Username);
                if (customerExists)
                {
                    ModelState.AddModelError("Username", "Username already exists");
                    return View(customerDto);
                }

                Customer customer = new Customer()
                {
                    Username = customerDto.Username,
                    Name = customerDto.Name,
                    Role = "Customer",
                    Email = customerDto.Email,
                    Address = customerDto.Address,
                    IsDeleted = false
                };

                await _customerRepository.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            else
            {
                return View(customerDto);
            }
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    public async Task<IActionResult> Edit(int id)
    {
        try
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null) return NotFound();

            return View(customer);
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Customer customer)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var customerFromDb = await _customerRepository.GetCustomerById(customer.Id);
                if (customerFromDb == null) return NotFound();

                if (customerFromDb.Username != customer.Username)
                {
                    bool customerExists = await _customerRepository.CheckIfCustomerExists(customer.Username);
                    if (customerExists)
                    {
                        ModelState.AddModelError("Name", "Customer already exists");
                        return View(customer);
                    }
                }

                customerFromDb.Username = customer.Username;
                customerFromDb.Name = customer.Name;
                customerFromDb.Email = customer.Email;
                customerFromDb.Address = customer.Address;

                await _customerRepository.UpdateCustomer(customerFromDb);
                return RedirectToAction("Index");
            }
            else
            {
                return View(customer);
            }
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null) return NotFound();

            return View(customer);
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Customer customer)
    {
        try
        {
            customer.IsDeleted = true;
            await _customerRepository.UpdateCustomer(customer);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    [HttpGet("/disabled-customers")]
    public async Task<IActionResult> DisabledCustomers()
    {
        try
        {
            var customers = await _customerRepository.GetAllDisabledCustomers();

            if (customers == null)
            {
                customers = [];
            }

            return View("Disabled", customers);
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }

    public async Task<IActionResult> RestoreCustomer(int id)
    {
        try
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null) return NotFound();

            customer.IsDeleted = false;
            await _customerRepository.UpdateCustomer(customer);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return View("Error", new { message = ex.Message });
        }
    }
}