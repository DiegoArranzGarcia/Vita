using System.Collections.Generic;
using Vita.Domain.Models;

namespace Vita.Application.UserCategories.Commands
{
    public interface ICreateUserCategoriesCommand
    {
        IEnumerable<UserCategory> Execute(IEnumerable<Category> categories, User user);
    }
}