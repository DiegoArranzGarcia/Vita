using System.Collections.Generic;
using Vita.Domain.UsersCategories;

namespace Vita.Application.UsersCategories
{
    public interface IUserCategoryService
    {
        IEnumerable<UserCategory> GetUserCategories(long userId);
        void CreateDefaultCategoriesForUser(long userId);
    }
}