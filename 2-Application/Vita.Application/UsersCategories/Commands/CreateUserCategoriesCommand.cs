using System.Collections.Generic;
using System.Linq;
using Vita.Domain.Categories;
using Vita.Domain.Users;
using Vita.Domain.UsersCategories;

namespace Vita.Application.UserCategories.Commands
{
    public class CreateUserCategoriesCommand : ICreateUserCategoriesCommand
    {
        private IUserCategoryRepository UserCategoryRepository { get; set; }

        public CreateUserCategoriesCommand(IUserCategoryRepository userCategoryRepository)
        {
            UserCategoryRepository = userCategoryRepository;
        }

        public IEnumerable<UserCategory> Execute(IEnumerable<Category> categories, User user)
        {
            var userCategories = categories.Select(category => new UserCategory()
            {
                UserId = user.Id,
                CategoryId = category.Id
            });

            foreach (var usercategory in userCategories)
            {
                UserCategoryRepository.Add(usercategory);
            }

            UserCategoryRepository.Save();

            return userCategories;
        }
    }
}
