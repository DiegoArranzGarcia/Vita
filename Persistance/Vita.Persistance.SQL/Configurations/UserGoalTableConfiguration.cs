using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vita.Domain.Models;

namespace Vita.Persistance.Sql.Configurations
{
    public class UserGoalTableConfiguration : IEntityTypeConfiguration<UserGoal>
    {
        public void Configure(EntityTypeBuilder<UserGoal> builder)
        {
            builder.HasKey(ug => ug.Id);

            builder.Property(ug => ug.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(ug => ug.UserId)
                   .IsRequired();

            builder.Property(ug => ug.GoalId)
                   .IsRequired();

            builder.HasAlternateKey(ug => new { ug.UserId, ug.GoalId });

            builder.HasOne(ug => ug.User)
                   .WithMany()
                   .HasForeignKey(ug => ug.UserId);

            builder.HasOne(ug => ug.Goal)
                   .WithMany()
                   .HasForeignKey(ug => ug.GoalId);
        }
    }
}
