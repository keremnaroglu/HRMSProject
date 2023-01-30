using HRMSProject.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.DAL.Concrete.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity> where TEntity : class, IBaseEntity where TContext : DbContext
    {
        TContext _db;
        private static DbSet<TEntity> _dbSet;

        public Repository(TContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Added;
            return _db.SaveChanges() > 0 ? entity : null;
        }

        public void Delete(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            return _db.Set<TEntity>().Where(filter).MyIncludes(includes).FirstOrDefault();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity Update(TEntity entity)
        {
            _db.ChangeTracker.Clear();
            _db.Entry(entity).State = EntityState.Modified;
            return _db.SaveChanges() > 0 ? entity : null;
        }
    }
}
