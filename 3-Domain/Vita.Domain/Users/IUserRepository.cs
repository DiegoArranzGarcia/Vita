using System;
using System.Collections.Generic;
using System.Text;
using Vita.Domain.Core;

namespace Vita.Domain.Users
{
    public interface IUserRepository : IRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUser(long userId);
        void Add(User user);
        void Delete(User user);
        void Update(User user);
    }
}
