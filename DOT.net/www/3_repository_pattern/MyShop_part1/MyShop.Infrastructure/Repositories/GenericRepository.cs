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
    // Abstract = to indicate that the class is intended only to be a base class of other classes and not instantiated.
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        // protected = accesable by all children of this class.
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

        public virtual T Get(int? id)
        {
            return _table.Find(id);
        }

        public virtual T Update(T obj)
        {
            _table.Update(obj);
            return obj;
        }
        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
