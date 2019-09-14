using Microsoft.EntityFrameworkCore;
using Vita.Persistance.Sql.Users;
using Vita.Domain.Models;
using Vita.Persistance.Sql.Configurations;
using System.Collections.Generic;

namespace Vita.Persistance.Sql
{
    public class VitaDbContext : DbContext
    {
        public DbSet<User> Users { get; }
        public DbSet<Category> Categories { get; }
        public DbSet<Goal> Goals { get; }
        public DbSet<UserCategory> UsersCategories { get; }
        public DbSet<UserGoal> UsersGoals { get; set; }

        public VitaDbContext(DbContextOptions<VitaDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryTableConfiguration());
            modelBuilder.ApplyConfiguration(new UserTableConfiguration());
            modelBuilder.ApplyConfiguration(new UserCategoryTableConfiguration());
            modelBuilder.ApplyConfiguration(new GoalTableConfiguration());
            modelBuilder.ApplyConfiguration(new UserGoalTableConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
