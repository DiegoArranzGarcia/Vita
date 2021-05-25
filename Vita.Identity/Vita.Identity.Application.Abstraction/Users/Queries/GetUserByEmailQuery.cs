using MediatR;

namespace Vita.Identity.Application.Abstraction.Users.Queries
{
    public class GetUserByEmailQuery : IRequest<UserDto>
    {
        public string Email { get; set; }
    }
}
