using MediatR;

namespace Vita.Identity.Application.Users.Queries
{
    public class GetUserByEmailQuery : IRequest<UserDto>
    {
        public string Email { get; set; }
    }
}
