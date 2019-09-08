using System.Collections.Generic;
using Vita.Domain.Core;

namespace Vita.Domain.Categories
{
    public interface ICategoryRepository : IRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
}
