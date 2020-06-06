using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vita.Identity.Domain.Aggregates.Users;
using Vita.Identity.Domain.Services;

namespace Vita.Identity.Application.Users.Commands
{
    public class ValidateUserPasswordQueryHandler : IRequestHandler<ValidateUserPasswordQuery, bool>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IPasswordService _passwordService;

        public ValidateUserPasswordQueryHandler(IUsersRepository usersRepository, IPasswordService passwordService)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _passwordService = passwordService ?? throw new ArgumentNullException(nameof(passwordService));
        }

        public async Task<bool> Handle(ValidateUserPasswordQuery query, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.FindByEmailAsync(query.Email);

            if (user == null)
                return false;

            return _passwordService.VerifyHashedPassword(user.PasswordHash, query.Password) != PasswordVerificationResult.Failed;
        }
    }
}
