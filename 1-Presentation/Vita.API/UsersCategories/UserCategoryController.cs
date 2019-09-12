using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vita.Application.UsersCategories.Queries;

namespace Vita.API.UsersCategories
{
    public class UserCategoryController : ControllerBase
    {
        private IGetAllUserCategoriesForUserQuery GetAllUserCategoriesForUserQuery { get; set; }
        private IMapper Mapper { get; set; }

        public UserCategoryController(IGetAllUserCategoriesForUserQuery getAllUserCategoriesForUserQuery, IMapper mapper)
        {
            GetAllUserCategoriesForUserQuery = getAllUserCategoriesForUserQuery;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("api/users/{userId}/categories")]
        public IEnumerable<UserCategoryDto> GetUserCategories(long userId)
        {
            return Mapper.ProjectTo<UserCategoryDto>(GetAllUserCategoriesForUserQuery.Execute(userId).AsQueryable());
        }
    }
}
