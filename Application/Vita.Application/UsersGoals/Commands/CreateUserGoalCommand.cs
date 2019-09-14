using Vita.Domain.Models;
using Vita.Persistance.Abstractions;

namespace Vita.Application.UsersGoals.Commands
{
    public class CreateUserGoalCommand : ICreateUserGoalCommand
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public CreateUserGoalCommand(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public UserGoal Execute(long userId, long categoryId, string title, string description)
        {
            var goal = new Goal()
            {
                Description = description,
                Title = title,
                CategoryId = categoryId,
            };

            UnitOfWork.GoalRepository.Add(goal);

            var userGoal = new UserGoal()
            {
                Goal = goal,
                UserId = userId,
            };

            UnitOfWork.UserGoalRepository.Add(userGoal);

            return userGoal;
        }
    }
}
