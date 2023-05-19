using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        //die base is het oproepen van de superklasse/baseklasse dus de GenericRepository
        public OrderRepository(ShoppingContext context) : base(context)
        {
        }

        public override Order Update(Order entity)
        {
            var order = _context.Orders.Single(p => p.OrderID == entity.OrderID);


            order.OrderDate = entity.OrderDate;
            order.Orderlines = entity.Orderlines;

            return base.Update(order);
        }

        public override IEnumerable<Order> All() {
            // include verwijst altijd naar de hoofd table => in dit geval de Orders, een thenInclude weerkaatst op de Include die voor de ThenInclude staat
            // zo verwijst de ThenInclude Product naar de Include Orderlines
            var orders = _context.Orders.Include(ol => ol.Orderlines).ThenInclude(or => or.Product).Include(cu => cu.Customer);
            return orders;
        }
    }
}
