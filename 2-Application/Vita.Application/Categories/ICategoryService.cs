using System.Collections.Generic;
using Vita.Domain.Categories;

namespace Vita.Application.Categories
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Category> GetDefaultCategories();
    }
}