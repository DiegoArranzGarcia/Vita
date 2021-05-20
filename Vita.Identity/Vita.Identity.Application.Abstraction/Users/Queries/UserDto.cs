using System;

namespace Vita.Identity.Application.Abstraction.Users.Queries
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}