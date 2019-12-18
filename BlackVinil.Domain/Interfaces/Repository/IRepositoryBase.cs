using BlackVinil.Domain.Entities;
using System.Collections.Generic;

namespace BlackVinil.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity :  class 
    {
        void Add(TEntity obj);
        void AddAll(IEnumerable<TEntity> entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();      
        void Update(TEntity entity);
        void Remove(TEntity entity);

    }
}
