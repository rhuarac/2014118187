using _2014118187_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2014118187_PER.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _Context;

        public Repository(DbContext context)
        {
            _Context = context;
        }

        void IRepository<TEntity>.Add(TEntity entity)
        {
            _Context.Set<TEntity>().Add(entity);
        }

        void IRepository<TEntity>.AddRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().AddRange(entities);
        }

        TEntity IRepository<TEntity>.Get(int? Id)
        {
            return _Context.Set<TEntity>().Find(Id);
        }

        IEnumerable<TEntity> IRepository<TEntity>.GetAll()
        {
            return _Context.Set<TEntity>().ToList();
        }

        IEnumerable<TEntity> IRepository<TEntity>.Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _Context.Set<TEntity>().Where(predicate);
        }

        void IRepository<TEntity>.Delete(TEntity entity)
        {
            _Context.Set<TEntity>().Remove(entity);
        }

        void IRepository<TEntity>.DeleteRanger(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
