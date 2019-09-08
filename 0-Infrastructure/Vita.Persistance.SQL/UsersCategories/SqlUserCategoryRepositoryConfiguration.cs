using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vita.Domain.UsersCategories;

namespace Vita.Persistance.Sql.UsersCategories
{
    public class SqlUserCategoryRepositoryConfiguration : IEntityTypeConfiguration<UserCategory>
    {
        public void Configure(EntityTypeBuilder<UserCategory> builder)
        {
            builder.HasKey(uc => uc.Id);

            builder.Property(uc => uc.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(uc => uc.UserId)
                   .IsRequired();

            builder.Property(uc => uc.CategoryId)
                   .IsRequired();

            builder.HasAlternateKey(uc => new { uc.UserId, uc.CategoryId });

            builder.HasOne(uc => uc.User).WithMany();
            builder.HasOne(uc => uc.Category).WithMany();
        }
    }
}
