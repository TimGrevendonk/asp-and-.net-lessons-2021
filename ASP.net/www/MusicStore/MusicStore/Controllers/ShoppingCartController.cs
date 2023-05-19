using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly StoreContext _context;

        // Constructor
        public ShoppingCartController(StoreContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var cart = new ShoppingCart(HttpContext, _context);
            var items = cart.GetCartItems().ToList();

            return View(items);
        }

        public IActionResult AddToCart(int id)
        {
            var cart = new ShoppingCart(HttpContext, _context);
            var album = _context.Albums.SingleOrDefault(a => a.AlbumID == id);
            cart.AddToCart(album);

            return RedirectToAction("index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var cart = new ShoppingCart(HttpContext, _context);
            var album = _context.Albums.SingleOrDefault(a => a.AlbumID == id);
            cart.RemoveFromCart(album);
            return RedirectToAction("index");
        }

        public IActionResult DeleteFromCart(int id)
        {
            var cart = new ShoppingCart(HttpContext, _context);
            var album = _context.Albums.SingleOrDefault(a => a.AlbumID == id);
            cart.DeleteFromCart(album);
            return RedirectToAction("index");
        }
    }
}
