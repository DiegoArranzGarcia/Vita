using System.Collections.Generic;
using Vita.Domain.UsersCategories;

namespace Vita.Application.UsersCategories.Queries
{
    public interface IGetAllUserCategoriesForUserQuery
    {
        IEnumerable<UserCategory> Execute(long userId);
    }
}