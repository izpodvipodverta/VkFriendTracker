using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity:Entity
    {
        private readonly DbContext _context;

        public Repository(DomainContext domainContext)
        {
            DbSet = domainContext.Set<TEntity>();
            _context = domainContext;
            Query = domainContext.Query<TEntity>();
        }

        public TEntity Create(TEntity entity)
        {
            var entityEntry = DbSet.Add(entity);
            _context.SaveChanges();
            return entityEntry.Entity;
        }

        public TEntity FindById(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public IEnumerable<TEntity> Filter(Func<TEntity, bool> filter)
        {
            return Query.Where(filter);
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            Remove(FindById(id));
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public DbSet<TEntity> DbSet { get; }
        public IQueryable<TEntity> Query { get; }
    }
}
