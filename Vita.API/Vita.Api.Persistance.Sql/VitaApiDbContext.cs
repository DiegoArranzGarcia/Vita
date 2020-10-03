using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Vita.Api.Domain.Aggregates.Categories;
using Vita.Api.Persistance.Sql.Aggregates.Categories;
using Vita.Api.Persistance.Sql.Aggregates.Goals;
using Vita.Core.Domain.Repositories;

namespace Vita.Api.Persistance.Sql
{
    public class VitaApiDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Category> Categories { get; private set; }
        public DbSet<Goal> Goals { get; private set; }

        public VitaApiDbContext(DbContextOptions<VitaApiDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new GoalsConfiguration());
            modelBuilder.ApplyConfiguration(new GoalStatusConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
