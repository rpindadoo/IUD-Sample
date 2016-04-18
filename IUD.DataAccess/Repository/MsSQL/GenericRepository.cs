using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using IUD.DataAccess.Context;
using IUD.DataAccess.Entities;

namespace IUD.DataAccess.Repository.MsSQL
{
    /// <summary>
    ///     MsSQL implementation of IRepository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly IDbContext _db;
        private readonly IDbSet<T> _entities;

        public GenericRepository(IDbContext context)
        {
            _db = context;
            _entities = _db.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _entities;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> criteria)
        {
            return GetAll().Where(criteria);
        }

        public virtual T GetById(int id)
        {
            return _entities.FirstOrDefault(p => p.Id == id);
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        public void Remove(ICollection<T> entities)
        {
            foreach (T entity in entities)
                Remove(entity);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}