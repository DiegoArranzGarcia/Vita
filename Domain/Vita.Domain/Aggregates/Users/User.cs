using System;
using Vita.Domain.Abstrations.Entities;
using Vita.Domain.Abstrations.Repositories;

namespace Vita.Domain.Aggregates.Users
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User(string name, string email)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
