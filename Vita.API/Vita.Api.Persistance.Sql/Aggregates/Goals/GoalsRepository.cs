using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Vita.Api.Domain.Aggregates.Goals;
using Vita.Core.Domain.Repositories;

namespace Vita.Api.Persistance.Sql.Aggregates.Goals
{
    public class GoalsRepository : IGoalsRepository
    {
        private readonly VitaApiDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public GoalsRepository(VitaApiDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Goal> FindByIdAsync(Guid id)
        {
            return await _context.Goals.FindAsync(id);
        }

        public Task<Goal> Add(Goal goal)
        {
            var entry = _context.Goals.Add(goal);
            return Task.FromResult(entry.Entity);
        }

        public Task<Goal> Update(Goal goal)
        {
            var entry = _context.Goals.Update(goal);
            return Task.FromResult(entry.Entity);
        }

        public async Task Delete(Guid id)
        {
            var goal = await FindByIdAsync(id);
            _context.Remove(goal);
        }
    }
}
