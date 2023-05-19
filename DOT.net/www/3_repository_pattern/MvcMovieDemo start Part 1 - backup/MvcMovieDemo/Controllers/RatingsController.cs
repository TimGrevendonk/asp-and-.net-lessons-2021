using System.Linq;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using MvcMovieDemo.DAL;
using MvcMovieDemo.Data;
using MvcMovieDemo.Models;

namespace MvcMovie.Controllers
{
    public class RatingsController : Controller
    {
        //private readonly MovieContext _context;
        private IRepository<Rating> ratingRepository;

        public RatingsController(MovieContext context)
        {
            //_context = context;    
            ratingRepository = new RatingRepository(context);
        }

        // GET: Ratings/List
        public IActionResult List()
        {
            //var ratings = _context.Ratings.OrderBy(r => r.Name);
            //return View(ratings.ToList());

            return View(ratingRepository.GetAll());
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
            //if (ModelState.IsValid)
            //{
            //    _context.Add(rating);
            //    _context.SaveChanges();
            //    return RedirectToAction("List");
            //}
            //return View(rating);

            if (ModelState.IsValid)
            {
                ratingRepository.Insert(rating);
                ratingRepository.Save();
                return RedirectToAction("List");
            }
            return View(rating);
        }

        // GET: Ratings/Edit/5
        public IActionResult Edit(int id)
        {
            //var rating = _context.Ratings.SingleOrDefault(r => r.RatingID == id)
            //return View(rating);
            
            return View(ratingRepository.GetByID(id));
        }

        // POST: Ratings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("RatingID,Code,Name")] Rating rating)
        {
            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(rating);
            //        _context.SaveChanges();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        throw;
            //    }
            //    return RedirectToAction("List");
            //}
            //return View(rating);

            if (ModelState.IsValid)
            {
                ratingRepository.Update(rating);
                ratingRepository.Save();
                return RedirectToAction("List");
            }
            return View(rating);
        }

        // GET: Ratings/Delete/5
        public IActionResult Delete(int id)
        {
            //var rating = _context.Ratings.SingleOrDefault(r => r.RatingID == id);
            //_context.Ratings.Remove(rating);
            //_context.SaveChanges();
            //return RedirectToAction("List");

            ratingRepository.Delete(id);
            ratingRepository.Save();
            return RedirectToAction("list");
        }

    }
}
