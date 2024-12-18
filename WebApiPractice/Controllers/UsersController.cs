using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiPractice.Data;
using WebApiPractice.Models;

namespace WebApiPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public ActionResult <List<User>> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if(user == null) return NotFound();

            return user;
        }


    }
}
