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
    // Abstract = to indicate that the class is intended only to be a base class of other classes.
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        // protected = accesable by all childs of this class.
        protected ShoppingContext _context;
        protected DbSet<T> _table = null;

        public GenericRepository(ShoppingContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        // Virtual = to indicate they can be overridden in the derived classes.
        public virtual T Add(T obj)
        {
            _table.Add(obj);
            return obj;
        }

        public virtual IEnumerable<T> All()
        {
            return _table.ToList();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _table;

            if (filter != null)
                query = query.Where(filter);
            // Return all object that correspond to the filter.
            return query.ToList();
        }

        public virtual T Get(int? id)
        {
            return _table.Find(id);
        }

        public virtual T Update(T obj)
        {
            _table.Update(obj);
            return obj;
        }

        /* Async Methods */

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async virtual Task<T> GetByIDAsync(int id)
        {
            return await _table.FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
                                            IOrderedQueryable<T>> orderBy = null,
                                            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }

        public async virtual Task<T> InsertAsync(T obj)
        {
            _table.Add(obj);
            return obj;
        }


        public async virtual Task UpdateAsync(int id, T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }




        // // will now be saved via UnitOfWork
        //public virtual void SaveChanges()
        //{
        //    _context.SaveChanges();
        //}
    }
}
