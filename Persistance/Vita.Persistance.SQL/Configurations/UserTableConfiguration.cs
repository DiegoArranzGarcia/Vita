using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vita.Domain.Models;

namespace Vita.Persistance.Sql.Users
{
    public class UserTableConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(u => u.Email)
                   .IsRequired();

            builder.Property(u => u.Name)
                   .IsRequired();

            builder.HasIndex(u => u.Email)
                   .IsUnique();
        }
    }
}
