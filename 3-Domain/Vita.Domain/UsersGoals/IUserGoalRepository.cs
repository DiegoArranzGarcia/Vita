using System;
using System.Collections.Generic;
using System.Text;
using Vita.Domain.Core;

namespace Vita.Domain.UsersGoals
{
    public interface IUserGoalRepository : IRepository
    {
        IEnumerable<UserGoal> GetAll();
        void Add(UserGoal userGoal);
    }
}
