using System;
using System.Collections.Generic;
using BlackVinil.Application.Interfaces;
using BlackVinil.Domain.Interfaces.Service;
using BlackVinil.Domain.Service;

namespace BlackVinil.Application
{ 
    public abstract class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _service;

        public AppServiceBase(IServiceBase<TEntity> service)
        {
            _service = service;
        }

        public void Add(TEntity entity)
        {
            _service.Add(entity);
        }

        public void AddAll(IEnumerable<TEntity> entity)
        {
            _service.AddAll(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _service.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            _service.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _service.Update(entity);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
