using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Web.Controllers
{
    public class CustomerController : Controller
    {
        //private readonly ShoppingContext _context;
        private readonly IRepository<Customer> _service;

        public CustomerController(IRepository<Customer> service)
        {
            //_context = context;
            _service = service;
        }

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                //var customers = _context.Customers.ToList();
                var customers = _service.All();
                return View(customers);
            }
            else
            {
                //var customers = new[] { _context.Customers.Find(id.Value) };
                var customers = new[] { _service.Get((int) id) };
                return View(customers);
            }
        }
    }
}
