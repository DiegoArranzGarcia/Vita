using System.Collections.Generic;
using Vita.Domain.UsersCategories;
using Vita.Domain.UsersGoals;

namespace Vita.Application.UsersGoals.Queries
{
    public interface IGetAllUserGoalForUserQuery
    {
        IEnumerable<UserGoal> Execute(long userId);
    }
}