using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal
        {
            get
            {
                return Orderlines.Sum(Item => Item.Product.Price * Item.Quantity);
            }
        }
        public ICollection<Orderline> Orderlines { get; set; }
        public Customer Customer { get; set; }
    }
}
