using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vita.Domain.UsersCategories;

namespace Vita.Application.UserCategories.Queries
{
    public class GetAllUserCategoriesForUserQuery : IGetAllUserCategoriesForUserQuery
    {
        private IUserCategoryRepository UserCategoryRepository { get; set; }

        public GetAllUserCategoriesForUserQuery(IUserCategoryRepository userCategoryRepository)
        {
            UserCategoryRepository = userCategoryRepository;
        }

        public IEnumerable<UserCategory> Execute(long userId)
        {
            return UserCategoryRepository.GetAllUsersCategories().Where(x => x.UserId == userId);
        }


    }
}
