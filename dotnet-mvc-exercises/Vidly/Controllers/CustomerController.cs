using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Create()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            ViewBag.MembershipTypes = membershipTypes;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (customer == null)
            {
                return View();
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            else
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null) return NotFound();
            var membershipTypes = _context.MembershipTypes.ToList();
            ViewBag.MembershipTypes = membershipTypes;

            return View("Create", customer);
        }

        public ActionResult Details(int id)
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            if (id > customers.Count || id < 1) return NotFound();

            var customer = customers[id - 1];
            return View(customer);
        }

    }
}
