using System.Collections.Generic;
using System.Linq;
using Vita.Domain.Models;
using Vita.Persistance.Abstractions;

namespace Vita.Application.UsersGoals.Queries
{
    public class GetAllUserGoalForUserQuery : IGetAllUserGoalForUserQuery
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public GetAllUserGoalForUserQuery(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<UserGoal> Execute(long userId)
        {
            return UnitOfWork.UserGoalRepository.GetAll().Where(x => x.UserId == userId);
        }
    }
}
