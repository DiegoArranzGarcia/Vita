using Vita.Domain.UsersGoals;

namespace Vita.Application.UsersGoals.Commands
{
    public class CreateUserGoalCommand : ICreateUserGoalCommand
    {
        private IUserGoalRepository UserGoalRepository { get; set; }

        public CreateUserGoalCommand(IUserGoalRepository userGoalRepository)
        {
            UserGoalRepository = userGoalRepository;
        }

        public UserGoal Execute(long userId, long categoryId, string title, string description)
        {
            var userGoal = new UserGoal()
            {
                Description = description,
                Title = title,
                CategoryId = categoryId,
                UserId = userId
            };

            UserGoalRepository.Add(userGoal);

            return userGoal;
        }
    }
}
