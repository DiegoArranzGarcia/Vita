using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vita.Application.UserCategories.Queries;

namespace Vita.API.UsersCategories
{
    public class UserCategoryController : ControllerBase
    {
        private IGetAllUserCategoriesForUserQuery GetAllUserGoalForUserQuery { get; set; }
        private IMapper Mapper { get; set; }

        public UserCategoryController(IGetAllUserCategoriesForUserQuery getAllUserGoalForUserQuery, IMapper mapper)
        {
            GetAllUserGoalForUserQuery = getAllUserGoalForUserQuery;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("api/users/{userId}/goals")]
        public IEnumerable<UserGoalDto> GetUserGoals(long userId)
        {
            return Mapper.ProjectTo<UserGoalDto>(GetAllUserGoalForUserQuery.Execute(userId).AsQueryable());
        }
    }
}
