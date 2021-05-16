using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CoffeeMachine.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Add(IEnumerable<T> entities);
        T GetById(params object[] keyValues);
        T GetFirstOrDefault(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true);
        IQueryable<T> GetAll();
        IEnumerable<T> GetMuliple(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(object id);
        void Delete(T entityToDelete);
        void Delete(IEnumerable<T> entities);
        bool Exists(Expression<Func<T, bool>> predicate);

    }
}
