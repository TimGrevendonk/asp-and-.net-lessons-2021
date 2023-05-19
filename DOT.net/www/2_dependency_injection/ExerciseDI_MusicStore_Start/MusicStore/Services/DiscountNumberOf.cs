using MusicStore.Models;
using System.Collections.Generic;

namespace MusicStore.Services
{
    public class DiscountNumberOf : IDiscountService
    {

        public int GetDiscount(List<CartItem> items)
        {
            int itemCount = 0;
            foreach (CartItem item in items)
            {
                itemCount += item.Count;
            }
            if (itemCount < 5)
            {
                return 0;
            }
            else if(itemCount < 10)
            {
                return 5;
            }
            else
            {
                return 10;
            }
            
        }
    }
}
