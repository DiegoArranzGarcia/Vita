using System.Collections.Generic;
using Vita.Domain.Models;

namespace Vita.Application.Categories.Queries
{
    public interface IGetAllCategoriesQuery
    {
        IEnumerable<Category> Execute();
    }
}
