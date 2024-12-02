using Microsoft.AspNetCore.Mvc;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movies = _context.Movies.ToList();
            if (id < 1 || id > movies.Count) return NotFound();

            var movie = movies[id - 1];
            return View(movie);
        }
    }
}
