using Vita.Domain.Models;

namespace Vita.Persistance.Abstractions
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<Goal> GoalRepository { get; }
        IGenericRepository<UserCategory> UserCategoryRepository { get; }
        IGenericRepository<UserGoal> UserGoalRepository { get; }

        void SaveChanges();
    }
}
