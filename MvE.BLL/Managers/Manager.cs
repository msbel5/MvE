using MvE.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MvE.BLL.Managers
{
    public class Manager<TEntity> : IManager<TEntity> where TEntity : class
    {
        public bool Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public bool Update(int entityId, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
