using Microsoft.AspNetCore.Mvc;
using SqlQueryPractice.Models;

namespace SqlQueryPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticeController : ControllerBase
    {
        private readonly SqlPracticeContext _context;

        public PracticeController(SqlPracticeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Practice()
        {
            var result = _context.Courses.ToList();
            return Ok(result);
        }
    }
}
