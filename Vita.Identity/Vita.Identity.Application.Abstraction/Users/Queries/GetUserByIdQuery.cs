using MediatR;
using System;

namespace Vita.Identity.Application.Abstraction.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}
