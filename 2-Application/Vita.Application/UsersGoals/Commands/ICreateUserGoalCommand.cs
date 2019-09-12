using Vita.Domain.UsersGoals;

namespace Vita.Application.UsersGoals.Commands
{
    public interface ICreateUserGoalCommand
    {
        UserGoal Execute(long userId, long categoryId, string title, string description);
    }
}