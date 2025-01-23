using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoshMVC.Data;
using MoshMVC.Models;

namespace MoshMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(c => 
                                        c.EmailAddress.ToLower() == loginDto.EmailAddress.ToLower() &&
                                        c.Password == loginDto.Password);

                if (customer == null)
                {
                    ModelState.AddModelError("EmailAddress", "Invalid credentials");
                    return View(loginDto);
                }

                var cookieOptions = new CookieOptions()
                {
                    Expires = DateTime.Now.AddHours(1),
                    //IsEssential = true,
                    HttpOnly = true,
                    Secure = true
                };

                Response.Cookies.Append("Name", customer.Name);

                return RedirectToAction("Index", "Movies");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }

        public IActionResult Logout()
        {
            try
            {
                Response.Cookies.Delete("Name");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }
    }
}
