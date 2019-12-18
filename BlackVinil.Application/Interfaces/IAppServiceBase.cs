using System.Collections.Generic;

namespace BlackVinil.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class 
    {
        void Add(TEntity obj);
        void AddAll(IEnumerable<TEntity> entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
