using Vita.Domain.Users;

namespace Vita.Application.Users
{
    public interface IUserService
    {
        User GetUser(int userId);
        User CreateUser(string name, string email);
    }
}