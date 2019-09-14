using System.Collections.Generic;
using Vita.Domain.Models;

namespace Vita.Application.UsersGoals.Queries
{
    public interface IGetAllUserGoalForUserQuery
    {
        IEnumerable<UserGoal> Execute(long userId);
    }
}