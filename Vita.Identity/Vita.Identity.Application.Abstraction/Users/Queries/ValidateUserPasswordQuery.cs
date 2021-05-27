using MediatR;

namespace Vita.Identity.Application.Abstraction.Users.Queries
{
    public class ValidateUserPasswordQuery : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
