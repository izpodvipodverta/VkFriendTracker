using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public interface IRepository<TEntity> where TEntity: Entity
    {
        TEntity Create(TEntity entity);
        TEntity FindById(int id);
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> Filter(Func<TEntity, bool> filter);
        void Remove(TEntity entity);
        void Remove(int id);
        void Update(TEntity entity);
        DbSet<TEntity> DbSet { get; }
        IQueryable<TEntity> Query { get; }
        
    }
}
