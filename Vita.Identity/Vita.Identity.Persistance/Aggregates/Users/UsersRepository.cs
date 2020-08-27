using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Vita.Core.Domain.Repositories;
using Vita.Identity.Domain.Aggregates.Users;

namespace Vita.Identity.Persistance.Sql.Aggregates.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly VitaIdentityDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public UsersRepository(VitaIdentityDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<User> Add(User user)
        {
            var entry = _context.Users.Add(user);
            return Task.FromResult(entry.Entity);
        }

        public async Task<User> FindByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id).ConfigureAwait(false);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<User> Update(User user)
        {
            var entry = _context.Users.Update(user);
            return Task.FromResult(entry.Entity);
        }
    }
}
