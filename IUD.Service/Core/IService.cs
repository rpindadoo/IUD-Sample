using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IUD.DataAccess.Entities;

namespace IUD.Service.Core
{
    /// <summary>
    ///     Exposes default functionality for each service implementation
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public interface IService<T>
        where T : class, IEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> criteria);
        T GetById(int id);
        void Add(T entity);
        void Remove(T entity);
        void Remove(ICollection<T> entities);
        void SaveChanges();
        bool Update(T entity);
    }
}