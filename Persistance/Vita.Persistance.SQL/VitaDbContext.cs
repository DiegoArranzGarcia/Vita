using Microsoft.EntityFrameworkCore;
using Vita.Persistance.Sql.Users;
using Vita.Persistance.Sql.Configurations;
using CodeReview.Domain.Abstractions.Repositories;
using System.Threading.Tasks;
using System.Threading;
using Vita.Domain.Aggregates.Categories;
using Vita.Domain.Aggregates.Users;

namespace Vita.Persistance.Sql
{
    public class VitaDbContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; }
        public DbSet<Category> Categories { get; }

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
