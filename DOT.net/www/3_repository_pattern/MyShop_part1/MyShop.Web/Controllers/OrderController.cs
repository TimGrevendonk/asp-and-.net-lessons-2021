using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;
using MyShop.Web.Models;

namespace MyShop.Web.Controllers
{
    public class OrderController : Controller
    {
        private IRepository<Order> _orderRepository;
        private IRepository<Product> _productRepository;

        public OrderController(IRepository<Product> productRepository, IRepository<Order> orderRepository)
        {
            // Make use of the IRepository<Type> , in startup.cs it maps the IRepository<Type> to the TypeRepository.
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            //var orders = _context.Orders
            //    .Include(order => order.Orderlines)
            //    .ThenInclude(orderline => orderline.Product).ToList();


            // Uses the All() method of the TypeRepository.
            return View(_orderRepository.All());
        }


        public IActionResult Create()
        {
            //var products = _context.Products.ToList();  
            //return View(products);

            // Uses the All() method of the TypeRepository.
            return View(_productRepository.All());  
        }

        [HttpPost]
        public IActionResult Create(CreateOrderModel model)
        {
            if (!model.LineItems.Any()) return BadRequest("Please submit line items");

            if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");

            var customer = new Customer
            {
                Name = model.Customer.Name,
                ShippingAddress = model.Customer.ShippingAddress,
                City = model.Customer.City,
                PostalCode = model.Customer.PostalCode,
                Country = model.Customer.Country
            };

            var order = new Order
            {
                Orderlines = model.LineItems
                    .Select(line => new Orderline { ProductID = line.ProductID, Quantity = line.Quantity })
                    .ToList(),
                OrderDate = DateTime.Now,
                Customer = customer
            };

            _orderRepository.Add(order);
            _orderRepository.SaveChanges();

            return Ok("Order Created");
        }

    }
}
