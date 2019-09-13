using System;
using Vita.Domain.Models;
using Vita.Persistance.Abstractions;
using Vita.Persistance.Sql.Repositories;

namespace Vita.Persistance.Sql
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private VitaDbContext VitaDbContext { get; set; }
        private bool Disposed { get; set; } = false;

        public IGenericRepository<Category> CategoryRepository { get; }
        public IGenericRepository<UserCategory> UserCategoryRepository { get; }
        public IGenericRepository<User> UserRepository { get; }

        public UnitOfWork(VitaDbContext vitaDbContext)
        {
            VitaDbContext = vitaDbContext;

            CategoryRepository = new GenericRepository<Category>(VitaDbContext);
            UserCategoryRepository = new GenericRepository<UserCategory>(VitaDbContext);
            UserRepository = new GenericRepository<User>(VitaDbContext);
        }

        public void SaveChanges()
        {
            VitaDbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed && disposing)
            {
                VitaDbContext.Dispose();
            }
            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
