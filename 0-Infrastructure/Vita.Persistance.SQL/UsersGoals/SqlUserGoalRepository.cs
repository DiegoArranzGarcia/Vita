using System;
using System.Collections.Generic;
using System.Text;
using Vita.Domain.UsersGoals;

namespace Vita.Persistance.Sql.UsersGoals
{
    public class SqlUserGoalRepository : IUserGoalRepository
    {
        private VitaDbContext VitaDbContext { get; set; }

        public SqlUserGoalRepository(VitaDbContext vitaDbContext)
        {
            VitaDbContext = vitaDbContext;
        }        

        public void Add(UserGoal userGoal)
        {
            VitaDbContext.Add(userGoal);
        }

        public IEnumerable<UserGoal> GetAll()
        {
            return VitaDbContext.UsersGoals;
        }

        public void Save()
        {
            VitaDbContext.SaveChanges();
        }
    }
}
