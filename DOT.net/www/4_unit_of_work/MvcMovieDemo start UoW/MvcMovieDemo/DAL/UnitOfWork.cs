using MvcMovieDemo.Data;
using MvcMovieDemo.Models;

namespace MvcMovieDemo.DAL
{
    // The class must implement the IUnitOfWork interface.
    public class UnitOfWork : IUnitOfWork
    {
        private MovieContext _context;
        private GenericRepository<Movie> movieRepository;
        private GenericRepository<Rating> ratingRepository;

        public UnitOfWork(MovieContext context)
        {
            _context = context;
        }

        public GenericRepository<Movie> MovieRepository
        {
            get { 
                if(movieRepository == null)
                {
                    movieRepository = new GenericRepository<Movie>(_context);
                } 
                return movieRepository;
            }
        }
        public GenericRepository<Rating> RatingRepository
        {
            get
            {
                if (ratingRepository == null)
                {
                    ratingRepository = new GenericRepository<Rating>(_context);
                }
                return ratingRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
