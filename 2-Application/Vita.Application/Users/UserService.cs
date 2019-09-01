using System;
using System.Collections.Generic;
using System.Text;
using Vita.Application.UsersCategories;
using Vita.Domain.Users;

namespace Vita.Application.Users
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository { get; set; }
        private IUserCategoryService UserCategoryService { get; set; }

        public UserService(IUserRepository userRepository, IUserCategoryService userCategoryService)
        {
            UserRepository = userRepository;
            UserCategoryService = userCategoryService;
        }     

        public User GetUser(int userId)
        {
            return UserRepository.GetUser(userId);
        }

        public User CreateUser(string name, string email)
        {
            var user = new User()
            {
                Email = email,
                Name = name
            };

            UserRepository.Add(user);
            UserRepository.Save();

            UserCategoryService.CreateDefaultCategoriesForUser(user.Id);

            return user;
        }
    }
}
