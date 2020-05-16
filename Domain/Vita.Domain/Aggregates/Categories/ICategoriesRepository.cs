using System;
using System.Threading.Tasks;
using Vita.Domain.Abstrations.Repositories;

namespace Vita.Domain.Aggregates.Categories
{
    public interface ICategoriesRepository : IRepository<Category>
    {
        Task<Category> Add(Category category);
        Task<Category> Update(Category category);
        Task<Category> FindByIdAsync(Guid id);
    }
}
