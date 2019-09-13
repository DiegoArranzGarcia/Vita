using Vita.Domain.Models;

namespace Vita.Persistance.Abstractions
{
    public interface IUnitOfWork
    {
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<UserCategory> UserCategoryRepository { get; }
        IGenericRepository<User> UserRepository { get; }

        void SaveChanges();
    }
}
