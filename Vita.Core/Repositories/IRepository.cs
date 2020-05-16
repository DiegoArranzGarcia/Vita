using CodeReview.Domain.Abstractions.Repositories;
using Vita.Domain.Abstrations.Entities;

namespace Vita.Domain.Abstrations.Repositories
{
    public interface IRepository<TEntity> : IAggregateRoot where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
