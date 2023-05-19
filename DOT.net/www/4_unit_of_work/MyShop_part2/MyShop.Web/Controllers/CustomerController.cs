using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Web.Controllers
{
    public class CustomerController : Controller
    {

        private IRepository<Customer> _customerRepository;

        public CustomerController(ShoppingContext context)
        {
            _customerRepository = new CustomerRepository(context);

            // Not the way with the best method of DI: ? ??? ???
            // var customerRepository = new GenericRepository<Customer>();
            // var customerRepository = new CustomerRepository(context);
        }

        // switched from "Guid? id" to "int? id", is this the way? ??? ??? ???
        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                // // Replaced the var-and-query with the method from GenericRepository->IRepsoitory 
                // var customers = _context.Customers.ToList();
                // return View(customers);
                return View(_customerRepository.All());
            }
            else
            {
                //  // Replaced the var-and-query with the method from GenericRepository->IRepsoitory 
                //var customers = new[] { _context.Customers.Find(id.Value) };
                //return View(customers);

                // Cast the "int?" to "int"
                return View( new[] { _customerRepository.Get((int)id) });
            }
        }
    }
}