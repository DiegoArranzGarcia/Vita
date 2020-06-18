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
        public string GivenName { get; private set; }
        public string FamilyName { get; private set; }

        public User(string email, string givenName, string familyName, string passwordHash)
        {
            Id = Guid.NewGuid();
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
            GivenName = givenName ?? throw new ArgumentNullException(nameof(givenName));
            FamilyName = familyName ?? throw new ArgumentNullException(nameof(familyName));
        }        

        public string GetFullName() 
        {
            return $"{GivenName} {FamilyName}".Trim();
        }

        public string GetUserName() 
        {
            return string.Join(".", new string[] { GivenName.ToLower(), FamilyName.ToLower() }).Trim();
        }
    }
}
