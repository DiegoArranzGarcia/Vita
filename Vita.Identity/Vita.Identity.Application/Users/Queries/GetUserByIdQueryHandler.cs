using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vita.Identity.Application.Abstraction.Users.Queries;
using Vita.Identity.Domain.Aggregates.Users;

namespace Vita.Identity.Application.Sql.Users.Queries
{
    public class GetUserByIdQueryHandler : IGetUserByIdQueryHandler
    {
        private readonly IUsersRepository _usersRepository;

        public GetUserByIdQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.FindByIdAsync(request.Id);
            return ToUserDto(user);
        }

        private UserDto ToUserDto(User user)
        {
            if (user == null)
                return null;

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                GivenName = user.GivenName,
                FamilyName = user.FamilyName,
                UserName = user.GetUserName(),
            };
        }
    }
}
