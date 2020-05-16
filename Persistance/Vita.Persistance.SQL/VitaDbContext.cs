using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Vita.Domain.Abstractions.Repositories;
using Vita.Domain.Aggregates.Categories;
using Vita.Domain.Aggregates.Users;
using Vita.Persistance.Sql.Aggregates.Categories;
using Vita.Persistance.Sql.Aggregates.Users;

namespace Vita.Persistance.Sql
{
    public class VitaDbContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; private set; }
        public DbSet<Category> Categories { get; private set; }

        public VitaDbContext(DbContextOptions<VitaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
