using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
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
        // The unitOfWork replaces all import of the Repositories.
        private IUnitOfWork _unitOfWork;

        // No need to use the ShoppingContext, the UnitOfWork already does that.
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            // Instead of calling the method on the repository directly, start from the unitOfWork the has implemented the repository.
            var orders = _unitOfWork.OrderRepository.All();
            return View(orders.ToList());
        }


        public IActionResult Create()
        {
            // Instead of calling the method on the repository directly, start from the unitOfWork the has implemented the repository.
            return View(_unitOfWork.ProductRepository.All());  
        }

        [HttpPost]
        public IActionResult Create(CreateOrderModel model)
        {
            if (!model.LineItems.Any()) return BadRequest("Please submit line items");

            if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");

            // Find the first customer with the same name given in the model.
            var customer = this._unitOfWork.CustomerRepository.Find(filter: c => c.Name == model.Customer.Name).FirstOrDefault();

            // If customer is null (through first) make a new customer. else keep the current customer.
            if (customer == null)
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
                customer.City = model.Customer.City;
                customer.Country = model.Customer.Country;
                customer.PostalCode = model.Customer.PostalCode;
                customer.ShippingAddress = model.Customer.ShippingAddress;

                _unitOfWork.CustomerRepository.Update(customer);
            }

            var order = new Order
            {
                Orderlines = model.LineItems
                    .Select(line => new Orderline { ProductID = line.ProductID, Quantity = line.Quantity })
                    .ToList(),
                OrderDate = DateTime.Now,
                Customer = customer
            };
            
            // Instead of calling the method on the repository directly, start from the unitOfWork the has implemented the repository.
            this._unitOfWork.OrderRepository.Add(order);
            // The SaveChanges is called on the UnitOfWork directly to save all changes in one go.
            this._unitOfWork.SaveChanges();

            return Ok("Order Created");
        }

    }
}
