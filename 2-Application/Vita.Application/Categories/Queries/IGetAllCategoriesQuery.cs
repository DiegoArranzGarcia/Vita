using System.Collections.Generic;
using Vita.Domain.Categories;

namespace Vita.Application.Categories.Queries
{
    public interface IGetAllCategoriesQuery
    {
        IEnumerable<Category> Execute();
    }
}
