﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2")]
        public decimal Price { get; set; }

        //Product - ProductOrder, is  1 to many relationship
        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
