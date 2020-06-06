using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Vita.Core.Domain.Repositories;
using Vita.Identity.Domain.Aggregates.Users;
using Vita.Identity.Persistance.Sql.Aggregates.Users;

namespace Vita.Identity.Persistance.Sql
{
    public class VitaIdentityDbContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; private set; }

        public VitaIdentityDbContext(DbContextOptions<VitaIdentityDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
