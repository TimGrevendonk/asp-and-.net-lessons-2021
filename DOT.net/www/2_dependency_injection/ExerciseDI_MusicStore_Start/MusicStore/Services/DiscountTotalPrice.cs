using MusicStore.Models;
using System.Collections.Generic;

namespace MusicStore.Services
{
    public class DiscountTotalPrice : IDiscountService
    {
        public int GetDiscount(List<CartItem> items)
        {
            int total = 0;
            foreach (CartItem item in items)
            {
                total += (item.Album.Price * item.Count);
            }
            // bigger or equal to 50 is 10 discount
            if (total >= 50)
            {
                return 10;
            }
            // between 25 and 50 is 5 discount
            else if (total >= 25)
            {
                return 5;
            }
            else
            {
                return 0;
            }

        }
    }
}
