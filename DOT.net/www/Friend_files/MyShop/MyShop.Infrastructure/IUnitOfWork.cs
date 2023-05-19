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
        OrderRepository OrderRepository { get; }
        CustomerRepository CustomerRepository { get; }
        ProductRepository ProductRepository { get; }

        void SaveChanges();

    }
}
