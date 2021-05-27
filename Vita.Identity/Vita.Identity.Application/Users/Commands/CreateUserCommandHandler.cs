using System;
using System.Threading;
using System.Threading.Tasks;
using Vita.Identity.Application.Abstraction.Users;
using Vita.Identity.Domain.Aggregates.Users;
using Vita.Identity.Domain.Services;

namespace Vita.Identity.Application.Sql.Users.Commands
{
    public class CreateUserCommandHandler : ICreateUserCommandHandler
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IPasswordService _passwordService;

        public CreateUserCommandHandler(IUsersRepository usersRepository, IPasswordService passwordService)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _passwordService = passwordService ?? throw new ArgumentNullException(nameof(passwordService));
        }

        public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User(command.Email, command.FirstName, command.LastName, _passwordService.HashPassword(command.Password));

            await _usersRepository.Add(user);
            await _usersRepository.UnitOfWork.SaveEntitiesAsync();

            return user.Id;
        }
    }
}
