using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vita.API.Users.Dtos;
using Vita.Application.Categories.Queries;
using Vita.Application.UserCategories.Commands;
using Vita.Application.Users.Commands;
using Vita.Domain.Models;

namespace Vita.API.Users
{
    public class UserController : ControllerBase
    {
        private ICreateUserCommand CreateUserCommand { get; set; }
        private ICreateUserCategoriesCommand CreateUserCategoriesCommand { get; set; }
        private IGetAllDefaultCategoriesQuery GetAllDefaultCategoriesQuery { get; set; }
        private IMapper Mapper { get; set; }

        public UserController(ICreateUserCommand createUserCommand,
                              ICreateUserCategoriesCommand createUserCategoriesCommand,
                              IGetAllDefaultCategoriesQuery getAllDefaultCategoriesQuery, 
                              IMapper mapper)
        {
            CreateUserCommand = createUserCommand;
            CreateUserCategoriesCommand = createUserCategoriesCommand;
            GetAllDefaultCategoriesQuery = getAllDefaultCategoriesQuery;
            Mapper = mapper;
        }


        [HttpPost]
        [Route("api/users")]
        public UserDto CreateUser(CreateUserDto createUserDto)
        {
            User user = CreateUserCommand.Execute(createUserDto.UserName, createUserDto.Email);

            var defaultCategories = GetAllDefaultCategoriesQuery.Execute();
            CreateUserCategoriesCommand.Execute(defaultCategories, user);

            return Mapper.Map<UserDto>(user);
        }
    }
}
