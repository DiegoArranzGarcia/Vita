using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Vita.Persistance.Abstractions;

namespace Vita.Persistance.Sql.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private VitaDbContext VitaDbContext { get; set; }
        private DbSet<TEntity> DbSet { get; }

        public GenericRepository(VitaDbContext vitaDbContext)
        {
            VitaDbContext = vitaDbContext;
            DbSet = vitaDbContext.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity Get(long id)
        {
            return DbSet.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (VitaDbContext.Entry(entity).State == EntityState.Detached)
                DbSet.Attach(entity);

            DbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            VitaDbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            VitaDbContext.SaveChanges();
        }
    }
}
