using System.Linq;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using MvcMovieDemo.Data;
using MvcMovieDemo.Models;
using MvcMovieDemo.DAL;
using System.Data;

namespace MvcMovie.Controllers
{
    public class RatingsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        // Uses seperate context's
        //private IRepository<Rating> ratingRepository;

        //public RatingsController(MovieContext context)
        //{
        //    //ratingRepository = new GenericRepository<Rating>(context);
        //}

        public RatingsController(IUnitOfWork unitOfWork)
        {
            // Uses same/shared context.
            this._unitOfWork = unitOfWork;
        }

        // GET: Ratings/List
        public IActionResult List()
        {

            return View(_unitOfWork.RatingRepository.GetAll());
        }

        // GET: Ratings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ratings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RatingID,Code,Name")] Rating rating)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.RatingRepository.Insert(rating);
                    _unitOfWork.Save();
                    return RedirectToAction("List");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");

            }     

            return View(rating);
        }

        // GET: Ratings/Edit/5
        public IActionResult Edit(int id)
        {
            return View(_unitOfWork.RatingRepository.GetByID(id));
        }

        // POST: Ratings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("RatingID,Code,Name")] Rating rating)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.RatingRepository.Update(rating);
                    _unitOfWork.Save();
                    return RedirectToAction("List");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return View(rating);
        }

        // GET: Ratings/Delete/5
        public IActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.RatingRepository.Delete(id);
                _unitOfWork.Save();
                return RedirectToAction("List");
            }
            catch (DataException)
            {
                throw;
            }

        }
    }
}

