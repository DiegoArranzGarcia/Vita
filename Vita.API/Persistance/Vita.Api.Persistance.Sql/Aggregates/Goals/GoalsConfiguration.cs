using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vita.Api.Persistance.Sql.Aggregates.Goals
{
    public class GoalsConfiguration : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.ToTable("Goals");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Title)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(g => g.CreatedBy)
                   .IsRequired();

            builder.Property(g => g.CreatedOn)
                   .HasColumnType("datetimeoffset(0)")
                   .IsRequired();

            builder.Property(g => g.Description)
                   .IsRequired(false)
                   .HasMaxLength(255);
        }
    }
}
