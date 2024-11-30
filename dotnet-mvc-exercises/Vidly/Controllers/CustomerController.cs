using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly List<Customer> _customers;
        public CustomerController()
        {
            _customers = new List<Customer>()
            {
                new Customer{Id = 1, Name = "John Smith"},
                new Customer{Id = 2, Name = "Mary Williams"}
            };
        }
        public IActionResult Index()
        {            
            return View(_customers);
        }

        public IActionResult Details(int id)
        {
            if (id > _customers.Count || id < 1) return NotFound();

            var customer = _customers[id - 1];
            return View(customer);
        }
    }
}
