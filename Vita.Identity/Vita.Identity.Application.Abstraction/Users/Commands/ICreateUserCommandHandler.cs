using MediatR;
using System;

namespace Vita.Identity.Application.Abstraction.Users
{
    public interface ICreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {

    }
}
