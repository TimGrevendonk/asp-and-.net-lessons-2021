using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        // base(...) = oproepen van de constructor van de base/super class
        public CustomerRepository(ShoppingContext context) : base(context)
        {
            // Sets the context in the GenericRepository.
        }

        public override Customer Update(Customer entity)
        {

            var customer = _context.Customers.Single(p => p.CustomerID == entity.CustomerID);

            customer.Name = entity.Name;
            customer.City = entity.City;
            customer.Country = entity.Country;
            customer.PostalCode = entity.PostalCode;
            customer.ShippingAddress = entity.ShippingAddress;

            return base.Update(customer);

        }
    }
}
