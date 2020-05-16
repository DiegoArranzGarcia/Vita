using System;
using System.Threading.Tasks;

namespace Vita.Application.Users.Queries
{
    public interface IUserQueries
    {
        Task<UserDto> GetUserByIdAsync(Guid userId);
    }
}
