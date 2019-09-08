using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vita.Application.UserCategories.Queries;
using Vita.Application.UsersGoals.Queries;

namespace Vita.API.UsersCategories
{
    public class UserGoalController : ControllerBase
    {
        private IGetAllUserGoalForUserQuery GetAllUserGoalForUserQuery { get; set; }
        private IMapper Mapper { get; set; }

        public UserGoalController(IGetAllUserGoalForUserQuery getAllUserGoalForUserQuery, IMapper mapper)
        {
            GetAllUserGoalForUserQuery = getAllUserGoalForUserQuery;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("api/users/{userId}/categories")]
        public IEnumerable<UserCategoryDto> GetUserCategories(long userId)
        {
            return Mapper.ProjectTo<UserCategoryDto>(GetAllUserGoalForUserQuery.Execute(userId).AsQueryable());
        }
    }
}
