using System.Collections.Generic;
using System.Linq;
using Vita.Domain.UsersGoals;

namespace Vita.Application.UsersGoals.Queries
{
    public class GetAllUserGoalForUserQuery : IGetAllUserGoalForUserQuery
    {
        private IUserGoalRepository UserGoalRepository { get; set; }

        public GetAllUserGoalForUserQuery(IUserGoalRepository userGoalRepository)
        {
            UserGoalRepository = userGoalRepository;
        }

        public IEnumerable<UserGoal> Execute(long userId)
        {
            return UserGoalRepository.GetAll().Where(x => x.UserId == userId);
        }
    }
}
