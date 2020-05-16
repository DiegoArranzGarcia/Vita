using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vita.Application.Categories.Queries
{
    public interface ICategoryQueries 
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesCreatedByUser(Guid userId);
        Task<IEnumerable<CategoryDto>> GetAllCategories();
        Task<CategoryDto> GetCategory(Guid id);
    }
}
