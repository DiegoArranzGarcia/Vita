using System;
using Vita.Core.Domain.Repositories;

namespace Vita.Identity.Domain.Aggregates.Users
{
    public class User : Entity
    {
        public string PasswordHash { get; set; }
        public string Email { get; private set; }

        public User(string email, string passwordHash)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
        }
    }
}
