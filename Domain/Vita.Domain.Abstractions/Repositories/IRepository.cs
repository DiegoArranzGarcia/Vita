namespace Vita.Domain.Abstractions.Repositories
{
    public interface IRepository<TEntity> : IAggregateRoot where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
