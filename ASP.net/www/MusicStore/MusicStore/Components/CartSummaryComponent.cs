using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Components
{
    // De naam van de component om te gebruiken in html.
    [ViewComponent(Name = "CartSummary")]
    public class CartSummaryComponent : ViewComponent
    {
        private readonly StoreContext _context;

        public CartSummaryComponent(StoreContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = new ShoppingCart(HttpContext, _context);

            // Sets the total items in a cart, en stuurt die naar de view.
            ViewData["CartCount"] = cart.GetCount();
            // Roept default.cshtml op (omdat het een component is) die van de variabele gebruik maakt.
            return View();
        }
    }
}