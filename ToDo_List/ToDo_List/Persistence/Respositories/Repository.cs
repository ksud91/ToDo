using ToDo_List.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ToDo_List.Persistence.Respositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> condition)
        {
            return Context.Set<TEntity>().Where(condition);
        }

        public void Add(TEntity obj)
        {
            Context.Set<TEntity>().Add(obj);
        }

        public void AddRange(IEnumerable<TEntity> objs)
        {
            Context.Set<TEntity>().AddRange(objs);
        }

        public void Remove(TEntity obj)
        {
            Context.Set<TEntity>().Remove(obj);
        }

        public void RemoveRange(IEnumerable<TEntity> objs)
        {
            Context.Set<TEntity>().RemoveRange(objs);
        }
    }
}
