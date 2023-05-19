using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string ShippingAddress { get; set; }
        public string City  { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
