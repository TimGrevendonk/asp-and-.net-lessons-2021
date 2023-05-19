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
        //private readonly ShoppingContext _context;
        private IUnitOfWork _uow;

        public OrderController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            //var orders = _context.Orders
            //    .Include(order => order.Orderlines)
            //    .ThenInclude(orderline => orderline.Product).ToList();
            var orders = _uow.OrderRepository.All();

            return View(orders);
        }


        public IActionResult Create()
        {
            //var products = _context.Products.ToList();
            var products = _uow.ProductRepository.All();
            
            return View(products);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderModel model)
        {
            if (!model.LineItems.Any()) return BadRequest("Please submit line items");

            if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");

            //var customer = _uow.CustomerRepository.Find(c => c.Name == model.Customer.Name).FirstOrDefault();
            var customer = _uow.CustomerRepository.Find(filter: c => c.Name == model.Customer.Name).FirstOrDefault();
            if (customer== null)
            {
                customer = new Customer
                {
                    Name = model.Customer.Name,
                    ShippingAddress = model.Customer.ShippingAddress,
                    City = model.Customer.City,
                    PostalCode = model.Customer.PostalCode,
                    Country = model.Customer.Country
                };
            }
            else
            {
                
                customer.ShippingAddress = model.Customer.ShippingAddress;
                customer.PostalCode = model.Customer.PostalCode;
                customer.City = model.Customer.City;
                customer.Country = model.Customer.Country;
                _uow.CustomerRepository.Update(customer);
            }

            //var customer = _uow.CustomerRepository.Find().FirstOrDefault();

            var order = new Order
            {
                Orderlines = model.LineItems
                    .Select(line => new Orderline { ProductID = line.ProductID, Quantity = line.Quantity })
                    .ToList(),
                OrderDate = DateTime.Now,
                Customer = customer
            };
            
            //_context.Orders.Add(order);
            //_context.SaveChanges();
            _uow.OrderRepository.Add(order);
            _uow.SaveChanges();
            return Ok("Order Created");
        }

    }
}
