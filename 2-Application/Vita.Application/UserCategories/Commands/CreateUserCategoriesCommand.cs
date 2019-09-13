using System.Collections.Generic;
using System.Linq;
using Vita.Domain.Models;
using Vita.Persistance.Abstractions;

namespace Vita.Application.UserCategories.Commands
{
    public class CreateUserCategoriesCommand : ICreateUserCategoriesCommand
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public CreateUserCategoriesCommand(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
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
                UnitOfWork.UserCategoryRepository.Add(usercategory);
            }

            UnitOfWork.SaveChanges();

            return userCategories;
        }
    }
}
