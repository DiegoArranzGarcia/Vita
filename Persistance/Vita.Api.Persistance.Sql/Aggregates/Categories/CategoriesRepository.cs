using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Vita.Api.Domain.Aggregates.Categories;
using Vita.Core.Domain.Repositories;

namespace Vita.Api.Persistance.Sql.Aggregates.Categories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly VitaApiDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public CategoriesRepository(VitaApiDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Category> FindByIdAsync(Guid id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Category> Add(Category category)
        {
            var entry = _context.Categories.Add(category);
            return Task.FromResult(entry.Entity);
        }

        public Task<Category> Update(Category category)
        {
            var entry = _context.Categories.Update(category);
            return Task.FromResult(entry.Entity);
        }
    }
}
