using Microsoft.EntityFrameworkCore;
using MvcMovieDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MvcMovieDemo.DAL
{
    public class GenericRepository<T> : IRepository<T> where T:class
    {
        private MovieContext _context;
        public DbSet<T> _table = null;

        public GenericRepository(MovieContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes
            )
        {
            IQueryable<T> query = _table;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public void Delete(int id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetByID(int id)
        {
            return _table.Find(id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _table.Update(obj);
        }
    }
}
