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
        /* Basic methods */
        IEnumerable<T> All();
        T Get(int? id);
        IEnumerable<T> Find(Expression<Func<T, bool>> filter = null);
        T Add(T obj);
        T Update(T obj);

        /* Async methods */
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIDAsync(int id);
        Task UpdateAsync(int id,T obj);
        Task<T> InsertAsync(T obj);
        Task DeleteAsync(int id);




        // // Is Replaced by the UnitOfWork SaveChanges.
        //void SaveChanges();

        //IEnumerable<T> Get(
        //    Expression<Func<T, bool>> filter = null,
        //    Func<IQueryable<T>,
        //    IOrderedQueryable<T>> orderBy = null,
        //    params Expression<Func<T, object>>[] includes
        //    );
    }
}
