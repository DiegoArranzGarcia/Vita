using System;

namespace Vita.Identity.Application.Users.Queries
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}