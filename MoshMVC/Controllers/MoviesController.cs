using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoshMVC.Data;
using MoshMVC.Models;

namespace MoshMVC.Controllers;

public class MoviesController : Controller
{
    private readonly ApplicationDbContext _context;
    public MoviesController(ApplicationDbContext context)
    {
        _context = context;
    }
    public ActionResult Index()
    {
        var movies = _context.Movies.ToList();
        return View(movies);
    }

    [Route("/movie/{id:int}")]
    public ActionResult MovieById(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
        if(movie == null) return NotFound();
        
        return View("Movie", movie);
    }

    public async Task<ActionResult> AddUpdate(int id)
    {
        try
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                var movie = await _context.Movies.FirstOrDefaultAsync(c => c.Id == id);
                if (movie == null) return NotFound();

                return View(movie);
            }
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View("Error");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> AddUpdate(Movie movie)
    {
        try
        {
            if (movie.Id == 0)
            {
                var movieExists = await _context.Movies.AnyAsync(c => c.Name.ToLower() == movie.Name.ToLower());
                if (!movieExists)
                {
                    await _context.Movies.AddAsync(movie);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Name", "Movie name already exists");
                }
            }
            else
            {
                _context.Movies.Update(movie);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(movie);
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View("Error");
        }
    }

    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(c => c.Id == id);
            if (movie == null) return NotFound();

            return View(movie);
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View("Error");
        }
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        try
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(c => c.Id == id);
            if (movie == null) return NotFound();

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View("Error");
        }
    }
}