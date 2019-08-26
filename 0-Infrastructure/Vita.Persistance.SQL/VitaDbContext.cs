using Microsoft.EntityFrameworkCore;
using Vita.Persistance.Sql.Categories;
using Vita.Domain.Categories;

namespace Vita.Persistance.Sql
{
    public class VitaDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public VitaDbContext(DbContextOptions<VitaDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SQLCategoryRepositoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
