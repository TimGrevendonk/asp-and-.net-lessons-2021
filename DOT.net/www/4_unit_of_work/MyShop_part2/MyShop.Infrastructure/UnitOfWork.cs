using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShoppingContext _context;
        private CustomerRepository customerRepository; 
        private OrderRepository orderRepository; 
        private ProductRepository productRepository;

        public UnitOfWork(ShoppingContext context)
        {
            _context = context;
        }

        public CustomerRepository CustomerRepository 
        {
            get
            {
                if(this.customerRepository == null)
                {
                    this.customerRepository = new CustomerRepository(_context);
                }
                return this.customerRepository;
            }
        }
        public OrderRepository OrderRepository
        {
            get
            {
                if(this.orderRepository == null)
                {
                    this.orderRepository = new OrderRepository(_context);
                }
                return this.orderRepository;
            }
        }

        public ProductRepository ProductRepository
        {
            get
            {
                if(this.productRepository == null)
                {
                    this.productRepository = new ProductRepository(_context);
                }
                return this.productRepository;
            }
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
