using MediatR;
using System;

namespace Vita.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
