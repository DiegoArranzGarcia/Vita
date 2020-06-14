using MediatR;

namespace Vita.Identity.Application.Users.Commands
{
    public class ValidateUserPasswordQuery : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
