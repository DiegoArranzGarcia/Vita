﻿using System;
using System.Threading.Tasks;
using Vita.Domain.Abstrations.Repositories;

namespace Vita.Domain.Aggregates.Users
{
    public interface IUsersRepository : IRepository<User>
    {
        Task<User> FindByIdAsync(Guid id);
        Task<User> Add(User user);
        Task<User> Update(User user);
    }
}
