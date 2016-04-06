using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Repo.Common;
using Repo.Example.Entities;

namespace Repo.Example.Repository
{
    internal class WorkerRepository : BaseRepository<Worker>
    {
        public WorkerRepository(DbContext context) : base(context)
        {
            Context = context;
        }

        #region IRepository

        public override void Create(Worker entity)
        {
            Context.Set<Worker>().Add(entity);
        }

        public override Worker Retrieve(int id)
        {
            return Context.Set<Worker>().Find(id);
        }

        public override void Update(Worker entity)
        {
            Context.Set<Worker>().Attach(entity);
        }

        public override void Delete(Worker entity)
        {
            Context.Set<Worker>().Remove(entity);
        }

        public override IQueryable<Worker> Query(Expression<Func<Worker, bool>> query)
        {
            return Context.Set<Worker>().Where(query);
        }

        #endregion

        public IEnumerable<Worker> SearchWorkers(Sex sex, MartialStatus status, int salary, string lastNameStartsWith)
        {
            var predicate = PredicateBuilder.True<Worker>();

            predicate.Or(w => w.Sex == sex || sex == Sex.Undefined)
                .Or(w => w.MartialStatus == status || status == MartialStatus.Unknown)
                .Or(w => w.YearlySalary > salary || salary == 0)
                .Or(w => string.IsNullOrWhiteSpace(lastNameStartsWith) || w.LastName.StartsWith(lastNameStartsWith));

            return Query(predicate);
        }
    }
}
