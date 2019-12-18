using System;
using System.Collections.Generic;
using BlackVinil.Domain.Entities;
using BlackVinil.Domain.Interfaces.Repository;
using BlackVinil.Domain.Interfaces.Service;


namespace BlackVinil.Domain.Service
{ 
    public abstract class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository =  repository;
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public void AddAll(IEnumerable<TEntity> entity)
        {
            _repository.AddAll(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }       

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
