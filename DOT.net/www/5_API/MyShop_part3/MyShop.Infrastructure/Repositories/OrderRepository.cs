using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        // base(...) = oproepen van de constructor van de base/super class
        public OrderRepository(ShoppingContext context) : base(context)
        {
            // Sets the context in the GenericRepository.
        }
        public override Order Update(Order entity)
        {
            var order = _context.Orders.Single(o => o.OrderID == entity.OrderID);

            order.OrderDate = entity.OrderDate;

            return base.Update(order);
        }

        public override IEnumerable<Order> All()
        {
            // ThenInclude is used to jump to the next table from an Include.
            // Chaining Include wil always start from the first/root table (Orders in this case) 
            return _context.Orders
                .Include(ol => ol.Orderlines)
                .ThenInclude(p => p.Product)
                .Include(c => c.Customer);
        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            var order = _context.Orders
                .Include(ol => ol.Orderlines)
                .ThenInclude(p => p.Product)
                .Include(c => c.Customer);
            return await order.ToListAsync();
        }
        public override async Task<Order> GetByIDAsync(int id)
        {
            var order = _context.Orders
                .Include(ol => ol.Orderlines)
                .ThenInclude(p => p.Product)
                .Include(c => c.Customer)
                .FirstOrDefault(o => o.OrderID == id);
            return order;
        }
    }
}
