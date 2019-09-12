using System.Collections.Generic;
using Vita.Domain.Categories;
using Vita.Domain.Users;
using Vita.Domain.UsersCategories;

namespace Vita.Application.UsersCategories.Commands
{
    public interface ICreateUserCategoriesCommand
    {
        IEnumerable<UserCategory> Execute(IEnumerable<Category> categories, User user);
    }
}