using System;
using System.Linq;
using System.Collections.Generic;
using BlackVinil.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using BlackVinil.Domain.Interfaces.Repository;
using BlackVinil.Domain.Entities;

namespace BlackVinil.Infra.Data.Repository
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {        
        protected BlackVinilContext Db = new BlackVinilContext();

        public void Add(TEntity entity)
        {           
            Db.Set<TEntity>().Add(entity);
            Db.SaveChanges();            
        } 
        
        public void AddAll(IEnumerable<TEntity> entity)
        {            
            Db.Set<TEntity>().AddRange(entity);
            Db.SaveChanges();            
        }

        public IEnumerable<TEntity> GetAll()
        {
           return Db.Set<TEntity>().ToList();
        }      

        public virtual TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            Db.Set<TEntity>().Remove(entity);
            Db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
        
    }
}
