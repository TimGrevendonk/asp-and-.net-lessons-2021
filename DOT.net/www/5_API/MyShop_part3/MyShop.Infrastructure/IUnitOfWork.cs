using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure
{
    public interface IUnitOfWork
    {
        CustomerRepository CustomerRepository { get; }
        OrderRepository OrderRepository { get; }
        ProductRepository ProductRepository { get; }
        void SaveChanges();
        Task SaveAsync();
    }
}
