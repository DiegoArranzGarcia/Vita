using Microsoft.EntityFrameworkCore;
using Vita.Persistance.Sql.Categories;
using Vita.Domain.Categories;
using Vita.Domain.UsersCategories;
using Vita.Domain.Users;
using Vita.Persistance.Sql.Users;
using Vita.Persistance.Sql.UserCategories;

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
            modelBuilder.ApplyConfiguration(new SqlCategoryRepositoryConfiguration());
            modelBuilder.ApplyConfiguration(new SqlUserRepositoryConfiguration());
            modelBuilder.ApplyConfiguration(new SqlUserCategoryRepositoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
