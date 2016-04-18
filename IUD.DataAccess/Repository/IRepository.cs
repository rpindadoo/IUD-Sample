using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IUD.DataAccess.Entities;

namespace IUD.DataAccess.Repository
{
    /// <summary>
    ///     Exposes default methods for CRUD functionality
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> criteria);
        T GetById(int id);
        void Add(T entity);
        void Remove(T entity);
        void Remove(ICollection<T> entities);
        void SaveChanges();
    }
}