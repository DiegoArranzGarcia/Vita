using System;
using System.Collections.Generic;
using System.Security.Claims;
using Vita.Core.Domain.Repositories;

namespace Vita.Identity.Domain.Aggregates.Users
{
    public class User : Entity
    {
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }


        //private readonly List<Claim> _claims;
        //public IReadOnlyCollection<Claim> Claims => _claims;

        public User(string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
            //_claims = new List<Claim>()
            //{
            //    new Claim("Subject", Id.ToString()),
            //    new Claim("Email", email),
            //    new Claim("EmailVerified", "true", ClaimValueTypes.Boolean)
            //};
        }        
    }
}
