using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product> 
    {
        // base(...) = oproepen van de constructor van de base/super class
        public ProductRepository(ShoppingContext context) : base(context)
        {
            // Sets the context in the GenericRepository.
        }
        public override Product Update(Product entity)
        {

            var product = _context.Products.Single(p => p.ProductID == entity.ProductID);

            product.Price = entity.Price;
            product.Name = entity.Name;

            return base.Update(product);

        }
    }
}
