using EntityHomework.Data;
using EntityHomework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityHomework.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly EntityHomeworkContext Context;

        public Repository(EntityHomeworkContext context)
        {
            Context = context;
        }

        public TEntity Get(int? id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

    }
}