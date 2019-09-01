using System.Collections.Generic;
using System.Linq;
using Vita.Application.Categories;
using Vita.Domain.UsersCategories;

namespace Vita.Application.UsersCategories
{
    public class UserCategoryService : IUserCategoryService
    {
        private IUserCategoryRepository UserCategoryRepository { get; set; }
        private ICategoryService CategoryService { get; set; }

        public UserCategoryService(IUserCategoryRepository userCategoryRepository, ICategoryService categoryService)
        {
            UserCategoryRepository = userCategoryRepository;
            CategoryService = categoryService;
        }

        public IEnumerable<UserCategory> GetUserCategories(long userId)
        {
            return UserCategoryRepository.GetAllUsersCategories().Where(x => x.UserId == userId);
        }

        public void CreateDefaultCategoriesForUser(long userId)
        {
            foreach (var category in CategoryService.GetDefaultCategories())
            {
                var userCategory = new UserCategory()
                {
                    UserId = userId,
                    CategoryId = category.Id
                };

                UserCategoryRepository.CreateUserCategory(userCategory);
            }
                
            UserCategoryRepository.Save();
        }
    }
}
