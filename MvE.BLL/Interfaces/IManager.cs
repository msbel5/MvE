using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MvE.BLL.Interfaces
{
    public interface IManager<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        bool Add(TEntity entity);
        bool AddRange(IEnumerable<TEntity> entities);
        bool Update(int entityId, TEntity entity);
        bool Remove(int Id);
        bool RemoveRange(IEnumerable<TEntity> entities);
    }
}
