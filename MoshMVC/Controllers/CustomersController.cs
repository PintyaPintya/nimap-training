using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoshMVC.Data;
using MoshMVC.Models;

namespace MoshMVC.Controllers;

public class CustomersController : Controller
{
    private readonly ApplicationDbContext _context;

    public CustomersController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResult> Index()
    {
        try
        {
            var customers = await _context.Customers
                        .Include(c => c.MembershipType)
                        .ToListAsync();
            return View(customers);
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View("Error");
        }
    }

    [Route("/customer/{id:int}")]
    public async Task<ActionResult> CustomerById(int id)
    {
        try
        {
            var customer = await _context.Customers
                        .Include(c => c.MembershipType)
                        .FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null) return NotFound();

            return View("Customer", customer);
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View("Error");
        }
    }

    public async Task<ActionResult> AddUpdate(int id)
    {
        try
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
                if (customer == null) return NotFound();

                return View(customer);
            }
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View("Error");
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddUpdate(Customer customer)
    {
        try
        {
            if (customer.Id == 0)
            {
                var customerExists = await _context.Customers.AnyAsync(c => c.Name.ToLower() == customer.Name.ToLower());
                if (!customerExists)
                {
                    await _context.Customers.AddAsync(customer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Name", "Customer name already exists");
                }
            }
            else
            {
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(customer);
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View("Error");
        }
    }

    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null) return NotFound();

            return View(customer);
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View("Error");
        }
    }

    [HttpPost]
    [HttpPost, ActionName("Delete")]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        try
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null) return NotFound();

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View("Error");
        }
    }
}