using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcMovieDemo.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovieDemo.Models.ViewModels;
using MvcMovieDemo.DAL;
using MvcMovieDemo.Models;
using System.Data;

namespace MvcMovieDemo.Controllers
{
    public class MoviesController : Controller
    {
        // uses context for all repositories.
        private IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;      
        }

        public IActionResult List(int ratingID = 0)
        {
            var listMoviesVM = new ListMoviesViewModel();


            if (ratingID != 0)
            {
               listMoviesVM.Movies = _unitOfWork.MovieRepository.GetAll().Where(m => m.RatingID == ratingID).OrderBy(m => m.Title).ToList();
            }
            else
            {
                listMoviesVM.Movies = _unitOfWork.MovieRepository.GetAll().OrderBy(m => m.Title).ToList();
            }

            listMoviesVM.Ratings =    new SelectList(_unitOfWork.RatingRepository.GetAll().OrderBy(r => r.Name),
                        "RatingID", "Name");
            listMoviesVM.ratingID = ratingID;

            return View(listMoviesVM);

        }

        //Movie object contains related rating. (~after extending generic repository with GET method)
        public IActionResult Details(int id)
        {
            var movie = _unitOfWork.MovieRepository.Get(filter: x => x.MovieID ==id, includes: x=> x.Rating).FirstOrDefault();

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["Ratings"] =
                new SelectList(
                    _unitOfWork.RatingRepository.GetAll()
                    .OrderBy(r => r.Name),
                    "RatingID",
                    "Name");

            return View();
        }

        //GET: Movies/Add
        public IActionResult Add()
        { 
            var addMovieVM = new AddMovieViewModel();

            addMovieVM.Movie = new Movie(); 

            return View(addMovieVM);
        }


        //POST: Movies/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([Bind("Movie,Code, Name")] AddMovieViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var rating = _unitOfWork.RatingRepository.Get
                        (r => r.Code == model.Code && r.Name == model.Name).FirstOrDefault();

                    if (rating == null)
                    {
                        rating = new Rating { Code = model.Code, Name = model.Name };
                        _unitOfWork.RatingRepository.Insert(rating);
                    }

                    model.Movie.Rating = rating;

                    _unitOfWork.MovieRepository.Insert(model.Movie);
                    _unitOfWork.Save();
                    return RedirectToAction("List");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return RedirectToAction("Add");
        }




        //POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MovieID,Title,ReleaseDate, Genre,RatingID")] Movie movie)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.MovieRepository.Insert(movie);
                    _unitOfWork.Save();
                    return RedirectToAction("List");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");

            }

            return RedirectToAction("Create");
        }
    }
}
