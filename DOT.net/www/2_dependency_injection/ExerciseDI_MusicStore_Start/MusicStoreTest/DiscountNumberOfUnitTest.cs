using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.Models;
using MusicStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreTest
{
    [TestClass]
    public class DiscountNumberOfUnitTest
    {
        [TestMethod]
        public void GetDiscount_ArticlesAmount1_Returns0()
        {
            List<CartItem> items = new List<CartItem>()
            {
                new CartItem { Count = 1}
            };
            DiscountNumberOf discount = new DiscountNumberOf();
            int result = discount.GetDiscount(items);

            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void GetDiscount_ArticlesAmount4_Returns0()
        {
            List<CartItem> items = new List<CartItem>()
            {
                new CartItem { Count = 2},
                new CartItem { Count = 2}
            };
            DiscountNumberOf discount = new DiscountNumberOf();
            int result = discount.GetDiscount(items);

            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void GetDiscount_ArticlesAmount5_Returns5()
        {
            List<CartItem> items = new List<CartItem>()
            {
                new CartItem { Count = 3},
                new CartItem { Count = 2}
            };
            DiscountNumberOf discount = new DiscountNumberOf();
            int result = discount.GetDiscount(items);

            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void GetDiscount_ArticlesAmount9_Returns5()
        {
            List<CartItem> items = new List<CartItem>()
            {
                new CartItem { Count = 3},
                new CartItem { Count = 2},
                new CartItem { Count = 4}
            };
            DiscountNumberOf discount = new DiscountNumberOf();
            int result = discount.GetDiscount(items);

            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void GetDiscount_ArticlesAmount10_Returns10()
        {
            List<CartItem> items = new List<CartItem>()
            {
                new CartItem { Count = 3},
                new CartItem { Count = 2},
                new CartItem { Count = 5}
            };
            DiscountNumberOf discount = new DiscountNumberOf();
            int result = discount.GetDiscount(items);

            Assert.AreEqual(10, result);
        }
    }
}
