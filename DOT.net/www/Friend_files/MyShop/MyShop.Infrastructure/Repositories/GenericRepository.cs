using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public abstract class  GenericRepository<T> : IRepository<T> where T : class
    {
        protected ShoppingContext _context;
        protected DbSet<T> _table = null;
        

        public GenericRepository(ShoppingContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public virtual T Add(T obj)
        {
            _table.Add(obj);
            return obj;
        }

        public virtual IEnumerable<T> All()
        {
            return _table.ToList();
        }

        public virtual T Get(int id)
        {
            return _table.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual T Update(T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            return obj;
        }



        public IEnumerable<T> Find(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _table;

            //foreach (Expression<Func<T, object>> include in includes)
            //    query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            return query.ToList();
        }
    }
}
