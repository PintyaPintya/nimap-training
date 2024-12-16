using Microsoft.AspNetCore.Mvc;
using WebApiPractice.Models;

namespace WebApiPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> Users = new List<User>
        {
            new User { Id = 1, Name = "Rakesh", Department = "IT", Gender = "Male", Salary = 1000 },
            new User { Id = 2, Name = "Priyanka", Department = "IT", Gender = "Female", Salary = 2000  },
            new User { Id = 3, Name = "Suresh", Department = "HR", Gender = "Male", Salary = 3000 },
            new User { Id = 4, Name = "Hina", Department = "HR", Gender = "Female", Salary = 4000 },
            new User { Id = 5, Name = "Pranaya", Department = "HR", Gender = "Male", Salary = 35000 },
            new User { Id = 6, Name = "Pooja", Department = "IT", Gender = "Female", Salary = 2500 },
        };

        [HttpGet]
        public IActionResult GetUsers([FromQuery(Name = "Dept")] string? Department)
        {
            if(string.IsNullOrEmpty(Department)) return Ok(Users);

            var filteredEmp = Users.Where(e => e.Department.Equals(Department, StringComparison.OrdinalIgnoreCase)).ToList();

            if(filteredEmp.Count > 0)
            {
                return Ok(filteredEmp);
            }

            return NotFound($"No Users Found with Department: {Department}");
        }
    }
}