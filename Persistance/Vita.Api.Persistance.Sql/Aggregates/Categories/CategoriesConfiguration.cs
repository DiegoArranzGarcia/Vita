using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vita.Api.Domain.Aggregates.Categories;

namespace Vita.Api.Persistance.Sql.Aggregates.Categories
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(c => c.Color)
                   .IsRequired();

            builder.Property(c => c.CreatedBy)
                   .IsRequired(false);
        }
    }
}
