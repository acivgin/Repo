using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Repo.Common;
using Repo.Example.Entities;

namespace Repo.Example.Repository
{
    public class CompanyRepository : BaseRepository<Company>
    {
        public CompanyRepository(DbContext context) : base(context)
        {
            Context = context;
        }

        public override void Create(Company entity)
        {
            Context.Set<Company>().Add(entity);
        }

        public override Company Retrieve(int id)
        {
            return Context.Set<Company>().Find(id);
        }

        public override void Update(Company entity)
        {
            Context.Set<Company>().Attach(entity);
        }

        public override void Delete(Company entity)
        {
            Context.Set<Company>().Remove(entity);
        }

        public override IQueryable<Company> Query(Expression<Func<Company, bool>> query)
        {
            return Context.Set<Company>().Where(query);
        }
    }
}