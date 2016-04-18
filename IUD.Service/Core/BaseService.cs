using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IUD.DataAccess.Entities;
using IUD.DataAccess.Repository;

namespace IUD.Service.Core
{
    /// <summary>
    ///     Default service implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T> : IService<T> where T : class, IEntity
    {
        private readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> criteria)
        {
            return _repository.Find(criteria);
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual void Add(T entity)
        {
            _repository.Add(entity);
        }

        public virtual void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public virtual void Remove(ICollection<T> entities)
        {
            _repository.Remove(entities);
        }

        public virtual void SaveChanges()
        {
            _repository.SaveChanges();
        }

        public virtual bool Update(T entity)
        {
            T entityDb = _repository.GetById(entity.Id);
            if (entityDb == null)
            {
                return false;
            }
            _repository.Remove(entityDb);
            _repository.Add(entity);
            return true;
        }
    }
}