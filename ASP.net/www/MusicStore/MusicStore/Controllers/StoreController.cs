using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreContext _context;

        // constructor.
        public StoreController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListGenres()
        {
            var genres = _context.Genres.OrderBy(g => g.Name).ToList();
            return View(genres);
        }

        public IActionResult ListAlbums(int id)
        {
            var genres = _context.Albums.OrderBy(a => a.Title)
                .Where(a => a.GenreID == id)
                .ToList();
            return View(genres);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Genre)
                .Include(a => a.Artist)
                .FirstOrDefaultAsync(m => m.AlbumID == id);

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }
    }
}
