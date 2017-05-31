using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2014118187_ENT.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //C REATES
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //R EADS
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        //U PDATES

        // void Update(TEntity entity);
        //void UpdateRange(IEnumerable<TEntity> entities);
        //D ELETES

        void Delete(TEntity entity);
        void DeleteRanger(IEnumerable<TEntity> entities);
    }
}
