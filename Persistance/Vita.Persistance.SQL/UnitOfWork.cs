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

        public IGenericRepository<UserCategory> UserCategoryRepository { get; }
        public IGenericRepository<Category> CategoryRepository { get; }
        public IGenericRepository<Goal> GoalRepository { get; }
        public IGenericRepository<User> UserRepository { get; }
        public IGenericRepository<UserGoal> UserGoalRepository { get; }      

        public UnitOfWork(VitaDbContext vitaDbContext)
        {
            VitaDbContext = vitaDbContext;

            CategoryRepository = new GenericRepository<Category>(VitaDbContext);
            UserCategoryRepository = new GenericRepository<UserCategory>(VitaDbContext);
            UserRepository = new GenericRepository<User>(VitaDbContext);
            UserGoalRepository = new GenericRepository<UserGoal>(VitaDbContext);
            GoalRepository = new GenericRepository<Goal>(VitaDbContext);
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
