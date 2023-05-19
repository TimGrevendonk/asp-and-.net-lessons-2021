using MvcMovieDemo.Models;

namespace MvcMovieDemo.DAL
{
    public interface IUnitOfWork
    {
        GenericRepository<Movie> MovieRepository { get; }
        GenericRepository<Rating> RatingRepository { get; }
        void Save();
    }
}
