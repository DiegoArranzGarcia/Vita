using System;
using System.Collections.Generic;
using Vita.Domain.Users;

namespace Vita.Persistance.Sql.Users
{
    public class SqlUserRepository : IUserRepository
    {
        private VitaDbContext VitaDbContext { get; set; }

        public SqlUserRepository(VitaDbContext vitaDbContext)
        {
            VitaDbContext = vitaDbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return VitaDbContext.Users;
        }

        public User GetUser(long userId)
        {
            return VitaDbContext.Users.Find(userId);
        }

        public void Add(User user)
        {
            VitaDbContext.Add(user);
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            VitaDbContext.SaveChanges();
        }

    }
}
