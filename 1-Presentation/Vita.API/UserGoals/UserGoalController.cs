using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vita.Application.UsersGoals.Commands;
using Vita.Application.UsersGoals.Queries;

namespace Vita.API.UsersCategories
{
    public class UserGoalController : ControllerBase
    {
        private IGetAllUserGoalForUserQuery GetAllUserGoalForUserQuery { get; set; }
        private ICreateUserGoalCommand CreateUserGoalCommand { get; set; }
        private IMapper Mapper { get; set; }

        public UserGoalController(IGetAllUserGoalForUserQuery getAllUserGoalForUserQuery, IMapper mapper)
        {
            GetAllUserGoalForUserQuery = getAllUserGoalForUserQuery;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("api/users/{userId}/goals")]
        public IEnumerable<UserCategoryDto> GetUserGoals(long userId)
        {
            return Mapper.ProjectTo<UserCategoryDto>(GetAllUserGoalForUserQuery.Execute(userId).AsQueryable());
        }


        [HttpPost]
        [Route("api/users/{userId}/goals")]
        public UserCategoryDto CreateUserGoal(long userId, long categoryId, string title, string description)
        {
            return Mapper.Map<UserCategoryDto>(CreateUserGoalCommand.Execute(userId, categoryId, title, description));
        }
    }
}
