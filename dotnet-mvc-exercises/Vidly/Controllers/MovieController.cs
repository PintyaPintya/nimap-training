using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Create()
        {
            var genres = _context.Genres.ToList();
            ViewBag.Genres = genres;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (movie == null) return View();
            
            if (movie.Id == 0)
            {
                movie.DateAdded = DateOnly.FromDateTime(DateTime.Now);
                _context.Movies.Add(movie);
            }
            else
            {
                _context.Movies.Update(movie);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (id <= 0) return RedirectToAction("Index");

            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null) return NotFound();

            var genres = _context.Genres.ToList();
            ViewBag.Genres = genres;

            return View("Create", movie);
        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            if (id < 1 || id > movies.Count) return NotFound();

            var movie = movies[id - 1];
            return View(movie);
        }
    }
}
