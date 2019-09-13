using Microsoft.EntityFrameworkCore;
using Vita.Persistance.Sql.Users;
using Vita.Domain.Models;
using Vita.Persistance.Sql.Configurations;

namespace Vita.Persistance.Sql
{
    public class VitaDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCategory> UsersCategories { get; set; }

        public VitaDbContext(DbContextOptions<VitaDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryTableConfiguration());
            modelBuilder.ApplyConfiguration(new SqlUserTableConfiguration());
            modelBuilder.ApplyConfiguration(new UserCategoryTableConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
