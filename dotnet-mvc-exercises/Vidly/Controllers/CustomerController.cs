using Microsoft.AspNetCore.Mvc;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {            
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = _context.Customers.ToList();
            if (id > customers.Count || id < 1) return NotFound();

            var customer = customers[id - 1];
            return View(customer);
        }
    }
}
