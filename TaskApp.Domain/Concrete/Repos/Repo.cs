using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TaskApp.Domain.Abstract.Repos;

namespace TaskApp.Domain.Concrete.Repos
{
    public class Repo<TEntity> : IRepo<TEntity> where TEntity : class
    {
        public DbContext Context { get; set; }

        public Repo(DbContext context)
        {
            Context = context;
        }

        public void Add(TEntity item)
        {
            Context.Set<TEntity>().Add(item);
        }

        public TEntity Get(int Id)
        {
            return Context.Set<TEntity>().Find(Id);
        }

        public void Remove(TEntity item)
        {
            Context.Set<TEntity>().Remove(item);
        }
    }
}
