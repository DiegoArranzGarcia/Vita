using Vita.Domain.Models;

namespace Vita.Application.UsersGoals.Commands
{
    public interface ICreateUserGoalCommand
    {
        UserGoal Execute(long userId, long categoryId, string title, string description);
    }
}