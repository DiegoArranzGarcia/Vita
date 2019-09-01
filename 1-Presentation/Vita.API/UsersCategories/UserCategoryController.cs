using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vita.Application.UsersCategories;

namespace Vita.API.UsersCategories
{
    public class UserCategoryController : ControllerBase
    {
        private IUserCategoryService UserCategoryService { get; set; }
        private IMapper Mapper { get; set; }

        public UserCategoryController(IUserCategoryService userCategoryService, IMapper mapper)
        {
            UserCategoryService = userCategoryService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("api/users/{userId}/categories")]
        public IEnumerable<UserCategoryDto> GetUserCategories(long userId)
        {
            return Mapper.ProjectTo<UserCategoryDto>(UserCategoryService.GetUserCategories(userId).AsQueryable());
        }
    }
}
