using System.Collections.Generic;
using Vita.Domain.Models;

namespace Vita.Application.Categories.Queries
{
    public interface IGetAllCategoriesOfUserQuery
    {
        IEnumerable<Category> Execute(long userId);
    }
}