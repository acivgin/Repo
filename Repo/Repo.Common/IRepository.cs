using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repo.Common
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        T Retrieve(int id);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Query(Expression<Func<T, bool>> query);
    }
}