using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Vita.Core.Domain.Repositories;
using Vita.Domain.Aggregates.Categories;

namespace Vita.Persistance.Sql.Aggregates.Categories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly VitaDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public CategoriesRepository(VitaDbContext context)
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
