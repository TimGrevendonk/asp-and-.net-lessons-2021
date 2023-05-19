﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        T Add(T obj);
        T Update(T obj);
        T Get(int? id);
        //IEnumerable<T> Get(
        //    Expression<Func<T, bool>> filter = null,
        //    Func<IQueryable<T>,
        //    IOrderedQueryable<T>> orderBy = null,
        //    params Expression<Func<T, object>>[] includes
        //    );
        IEnumerable<T> Find(Expression<Func<T, bool>> filter = null);
        IEnumerable<T> All();

        // // Is Replaced by the UnitOfWork SaveChanges.
        //void SaveChanges();
    }
}
