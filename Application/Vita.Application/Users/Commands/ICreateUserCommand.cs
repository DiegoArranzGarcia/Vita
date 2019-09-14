using Vita.Domain.Models;

namespace Vita.Application.Users.Commands
{
    public interface ICreateUserCommand
    {
        User Execute(string name, string email);
    }
}