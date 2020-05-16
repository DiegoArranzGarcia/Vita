using MediatR;

namespace Vita.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
