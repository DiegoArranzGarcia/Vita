using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeReview.Domain.Abstractions.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
