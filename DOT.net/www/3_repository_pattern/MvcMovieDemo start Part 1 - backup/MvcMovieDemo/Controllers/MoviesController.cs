using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcMovieDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovieDemo.Models.ViewModels;
using MvcMovieDemo.Models;
using MvcMovieDemo.DAL;

namespace MvcMovieDemo.Controllers
{
    public class MoviesController : Controller
    {
        //private readonly MovieContext _context;
        private IRepository<Movie> _movieRepository;
        private IRepository<Rating> _ratingRepository;

        public MoviesController(MovieContext context)
        {
            //_context = context;
            _movieRepository = new MovieRepository(context);
            _ratingRepository = new RatingRepository(context);
        }

        public IActionResult List(int ratingID = 0)
        {
            //var listMoviesVM = new ListMoviesViewModel();
            //if (ratingID != 0)
            //{
            //   listMoviesVM.Movies = _context.Movies.Where(m => m.RatingID == ratingID).OrderBy(m => m.Title).ToList();
            //}
            //else
            //{
            //    listMoviesVM.Movies = _context.Movies.OrderBy(m => m.Title).ToList();
            //}
            //listMoviesVM.Ratings =    new SelectList(_context.Ratings.OrderBy(r => r.Name),
            //            "RatingID", "Name");
            //listMoviesVM.ratingID = ratingID;
            //return View(listMoviesVM);

            var listMoviesVM = new ListMoviesViewModel();

            if (ratingID != 0)
            {
                listMoviesVM.Movies = _movieRepository.GetAll().Where(m => m.RatingID == ratingID).OrderBy(m => m.Title).ToList();
            }
            else
            {
                listMoviesVM.Movies = _movieRepository.GetAll().OrderBy(m => m.Title).ToList();
            }

            listMoviesVM.Ratings = new SelectList(_ratingRepository.GetAll().OrderBy(r => r.Name),
                        "RatingID", "Name");
            listMoviesVM.ratingID = ratingID;

            return View(listMoviesVM);

        }


        public IActionResult Details(int id)
        {
            //var movie = _context.Movies
            //                .Include(m => m.Rating)
            //                .SingleOrDefault(m => m.MovieID == id);
            //return View(movie);

            return View(_movieRepository.GetByID(id));
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            //ViewData["Ratings"] =
            //    new SelectList(_context.Ratings.OrderBy(r => r.Name),
            //                   "RatingID",
            //                   "Name");
            //return View();


            return View();
        }

        //POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MovieId,Title, Genre,ReleaseDate, RatingID")] Movie movie)
        {
            // if (ModelState.IsValid)
            // {
            //     _context.Add(movie);
            //     _context.SaveChanges();
            //     return RedirectToAction("List");
            // }

            // //when insert doesn't succeed:
            //ViewData["Ratings"] =
            //new SelectList(_context.Ratings.OrderBy(r => r.Name),
            //               "RatingID",
            //               "Name");
            // return View(movie);

            if (ModelState.IsValid)
            {
                _movieRepository.Insert(movie);
                _movieRepository.Save();
                return RedirectToAction("List");
            }
            ViewData["Ratings"] = new SelectList(_ratingRepository.GetAll().OrderBy(r => r.Name),
                           "RatingID", "Name");

            return View();
        }

    }
}
