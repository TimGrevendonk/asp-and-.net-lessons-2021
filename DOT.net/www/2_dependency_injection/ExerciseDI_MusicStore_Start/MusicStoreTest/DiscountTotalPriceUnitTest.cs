using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.Models;
using MusicStore.Services;
using System.Collections.Generic;

namespace MusicStoreTest
{
    [TestClass]
    public class DiscountTotalPriceUnitTest
    {
        [TestMethod]
        public void GetDiscount_ArticlesPrice0_Returns0()
        {
            List<CartItem> items = new List<CartItem>()
            {
            };
            DiscountTotalPrice discount = new DiscountTotalPrice();
            int result = discount.GetDiscount(items);

            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void GetDiscount_ArticlesPrice10_Returns0()
        {
            List<CartItem> items = new List<CartItem>()
            {
                new CartItem { Count = 1, Album = new Album { Price = 5 } },
                new CartItem { Count = 1, Album = new Album { Price = 5 } }
            };
            DiscountTotalPrice discount = new DiscountTotalPrice();
            int result = discount.GetDiscount(items);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetDiscount_ArticlesPrice24_Returns0()
        {
            List<CartItem> items = new List<CartItem>()
            {
                new CartItem { Count = 1, Album = new Album { Price = 3 } },
                new CartItem { Count = 2, Album = new Album { Price = 10 } },
                new CartItem { Count = 1, Album = new Album { Price = 1 } }
            };
            DiscountTotalPrice discount = new DiscountTotalPrice();
            int result = discount.GetDiscount(items);

            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void GetDiscount_ArticlesPrice25_Returns5()
        {
            List<CartItem> items = new List<CartItem>()
            {
                new CartItem { Count = 1, Album = new Album { Price = 5 } },
                new CartItem { Count = 2, Album = new Album { Price = 10 } }
            };
            DiscountTotalPrice discount = new DiscountTotalPrice();
            int result = discount.GetDiscount(items);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void GetDiscount_ArticlesPrice30_Returns5()
        {
            List<CartItem> items = new List<CartItem>()
            {
                new CartItem { Count = 1, Album = new Album { Price = 10 } },
                new CartItem { Count = 1, Album = new Album { Price = 15 } },
                new CartItem { Count = 1, Album = new Album { Price = 5 } }
            };
            DiscountTotalPrice discount = new DiscountTotalPrice();
            int result = discount.GetDiscount(items);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void GetDiscount_ArticlesPrice49_Returns5()
        {
            List<CartItem> items = new List<CartItem>()
            {
                new CartItem { Count = 4, Album = new Album { Price = 5 } },
                new CartItem { Count = 2, Album = new Album { Price = 10 } },
                new CartItem { Count = 1, Album = new Album { Price = 9 } }
            };
            DiscountTotalPrice discount = new DiscountTotalPrice();
            int result = discount.GetDiscount(items);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void GetDiscount_ArticlesPrice50_Returns10()
        {
            List<CartItem> items = new List<CartItem>()
            {
                new CartItem { Count = 2, Album = new Album { Price = 5 } },
                new CartItem { Count = 2, Album = new Album { Price = 10 } },
                new CartItem { Count = 5, Album = new Album { Price = 4 } }
            };
            DiscountTotalPrice discount = new DiscountTotalPrice();
            int result = discount.GetDiscount(items);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void GetDiscount_ArticlesPrice60_Returns1O()
        {
            List<CartItem> items = new List<CartItem>()
            {
                new CartItem { Count = 2, Album = new Album { Price = 10 } },
                new CartItem { Count = 1, Album = new Album { Price = 5 } },
                new CartItem { Count = 1, Album = new Album { Price = 15 } },
                new CartItem { Count = 2, Album = new Album { Price = 5 } }
            };
            DiscountTotalPrice discount = new DiscountTotalPrice();
            int result = discount.GetDiscount(items);

            Assert.AreEqual(10, result);
        }
    }
}
