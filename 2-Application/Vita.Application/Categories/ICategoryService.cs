using System.Collections.Generic;
using Vita.Domain.Categories;

namespace Vita.Application.Categories
{
    public interface ICategoriesService
    {
        IEnumerable<Category> GetAllCategories();
    }
}