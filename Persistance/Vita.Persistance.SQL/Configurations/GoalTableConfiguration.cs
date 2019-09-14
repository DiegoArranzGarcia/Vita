using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vita.Domain.Models;

namespace Vita.Persistance.Sql.Configurations
{
    public class GoalTableConfiguration : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(g => g.Title)
                   .IsRequired();

            builder.Property(g => g.Description);

            builder.Property(g => g.CategoryId);

            builder.HasOne(g => g.Category).WithMany().HasForeignKey(g => g.CategoryId);
        }
    }
}
