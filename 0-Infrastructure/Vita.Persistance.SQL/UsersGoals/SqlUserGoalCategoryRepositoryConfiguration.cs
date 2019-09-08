using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vita.Domain.UsersGoals;

namespace Vita.Persistance.Sql.UsersGoals
{
    public class SqlUserGoalCategoryRepositoryConfiguration : IEntityTypeConfiguration<UserGoal>
    {
        public void Configure(EntityTypeBuilder<UserGoal> builder)
        {
            builder.HasKey(ug => ug.Id);

            builder.Property(ug => ug.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(ug => ug.Title)
                   .IsRequired();

            builder.Property(ug => ug.UserId)
                   .IsRequired();

            builder.Property(ug => ug.CategoryId)
                   .IsRequired();

            builder.HasAlternateKey(ug => new { ug.UserId, ug.CategoryId });

            builder.HasOne(ug => ug.User).WithMany();
            builder.HasOne(ug => ug.Category).WithMany();
        }
    }
}
