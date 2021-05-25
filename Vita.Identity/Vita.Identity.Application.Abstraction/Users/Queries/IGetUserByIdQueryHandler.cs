using MediatR;

namespace Vita.Identity.Application.Abstraction.Users.Queries
{
    public interface IGetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
    }
}
