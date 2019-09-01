using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vita.Application.Users;

namespace Vita.API.Users
{
    public class UserController : ControllerBase
    {
        private IUserService UserService { get; set; }
        private IMapper Mapper { get; set; }

        public UserController(IUserService userService, IMapper mapper)
        {
            UserService = userService;
            Mapper = mapper;
        }


        [HttpPost]
        [Route("api/users")]
        public UserDto CreateUser(CreateUserDto createUserDto)
        {
            return Mapper.Map<UserDto>(UserService.CreateUser(createUserDto.UserName, createUserDto.Email));
        }
    }
}
