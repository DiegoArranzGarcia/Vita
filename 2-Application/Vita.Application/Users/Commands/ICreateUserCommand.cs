using Vita.Domain.Users;

namespace Vita.Application.Users.Commands
{
    public interface ICreateUserCommand
    {
        User Execute(string name, string email);
    }
}