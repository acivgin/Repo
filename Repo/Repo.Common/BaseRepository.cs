using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Repo.Common
{
    public abstract class BaseRepository<T> : IRepository<T>, IDisposable where T : class
    {
        private bool _disposed;
        protected DbContext Context;

        protected BaseRepository(DbContext context)
        {
            if(_disposed)
                throw new ObjectDisposedException("Context");

            Context = context;
        }

        public abstract void Create(T entity);
        public abstract T Retrieve(int id);
        public abstract void Update(T entity);
        public abstract void Delete(T entity);
        public abstract IQueryable<T> Query(Expression<Func<T, bool>> query);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            if (Context == null)
                return;

            Context.Dispose();
            Context = null;

            _disposed = true;
        }
    }
}