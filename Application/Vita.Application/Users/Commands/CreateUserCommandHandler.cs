using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vita.Domain.Aggregates.Users;

namespace Vita.Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUsersRepository _usersRepository;

        public CreateUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository ?? throw new System.ArgumentNullException(nameof(usersRepository));
        }

        public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User(command.Name, command.Email);

            await _usersRepository.Add(user);
            await _usersRepository.UnitOfWork.SaveEntitiesAsync();

            return user.Id;
        }
    }
}
