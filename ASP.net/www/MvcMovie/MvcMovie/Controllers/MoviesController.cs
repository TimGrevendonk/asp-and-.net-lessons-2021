using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models.ViewModels;
using System.Linq;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;

        // The constructor.
        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        // Methods.
        public IActionResult List(int ratingID = 0)
        {
            var listMoviesVM = new ListMoviesViewModel();

            if (ratingID != 0)
            {
                // Fill the movies in the variable.
                listMoviesVM.Movies = _context.Movies.Where(m => m.RatingID == ratingID).OrderBy(m => m.Title).ToList();
            }
            else
            {
                listMoviesVM.Movies = _context.Movies.OrderBy(m => m.Title).ToList();
            }

            listMoviesVM.Ratings =
                new SelectList(_context.Ratings.OrderBy(r => r.Name),
                                "RatingID",
                                // de waarde die ge ziet in de wepbage.
                                "Name");
            listMoviesVM.ratingID = ratingID;

            return View(listMoviesVM);
        }


        public IActionResult Details(int id)
        {
            var movie = _context.Movies
                            .Include(m => m.Rating)
                            .SingleOrDefault(m => m.MovieID == id);

            return View(movie);
        }
        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["Ratings"] =
                // selectlist parameters: the object to list, what we are interested in in the object, what will the user see.
                // SelectList = ratings sorted on name. the objects
                new SelectList(_context.Ratings.OrderBy(r => r.Name),
                // With the ID of the rating. what am i interested in
                    "RatingID",
                // And with the name of the rating. what will the user see.
                    "Name");

            return View();
        }


    }
}
