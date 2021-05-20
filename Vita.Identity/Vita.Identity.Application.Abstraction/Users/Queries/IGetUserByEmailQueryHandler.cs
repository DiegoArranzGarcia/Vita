using MediatR;

namespace Vita.Identity.Application.Abstraction.Users.Queries
{
    public interface IGetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDto>
    {

    }
}
