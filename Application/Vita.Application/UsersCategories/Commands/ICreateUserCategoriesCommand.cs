using System.Collections.Generic;
using Vita.Domain.Models;

namespace Vita.Application.UsersCategories.Commands
{
    public interface ICreateUserCategoriesCommand
    {
        IEnumerable<UserCategory> Execute(IEnumerable<Category> categories, User user);
    }
}