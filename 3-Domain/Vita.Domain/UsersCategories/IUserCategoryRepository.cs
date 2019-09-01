using System;
using System.Collections.Generic;
using Vita.Domain.Core;

namespace Vita.Domain.UsersCategories
{
    public interface IUserCategoryRepository : IRepository
    {
        IEnumerable<UserCategory> GetAllUsersCategories();
        void CreateUserCategory(UserCategory userCategory);
    }
}
