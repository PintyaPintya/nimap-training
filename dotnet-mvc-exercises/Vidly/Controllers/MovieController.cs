using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private readonly List<Movie> _movies;
        public MovieController()
        {
            _movies = new List<Movie>
            {
                //new Movie{Id = 1, Name = "Shrek"},
                //new Movie{Id = 2, Name = "Wall-e"}
            };
        }
        public IActionResult Index()
        {
            return View(_movies);
        }

        public IActionResult Details(int id)
        {
            if (id < 1 || id > _movies.Count) return NotFound();

            var movie = _movies[id - 1];
            return View(movie);
        }
    }
}
