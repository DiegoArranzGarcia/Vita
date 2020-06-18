using System;
using System.Threading.Tasks;
using Vita.Core.Domain.Repositories;

namespace Vita.Api.Domain.Aggregates.Goals
{
    public interface IGoalsRepository : IRepository<Goal>
    {
        Task<Goal> Add(Goal Goal);
        Task<Goal> Update(Goal Goal);
        Task<Goal> FindByIdAsync(Guid id);
    }
}
