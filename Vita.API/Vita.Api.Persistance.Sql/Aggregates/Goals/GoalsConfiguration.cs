using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Vita.Api.Domain.Aggregates.Goals;

namespace Vita.Api.Persistance.Sql.Aggregates.Goals
{
    public class GoalsConfiguration : IEntityTypeConfiguration<Goal>
    {       
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.ToTable("Goals");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Title)
                   .HasColumnName(nameof(Goal.Title))
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(g => g.CreatedBy)
                   .HasColumnName(nameof(Goal.CreatedBy))
                   .IsRequired();

            builder.Property<int>("_goalStatusId")
                   .HasColumnName("GoalStatusId")
                   .IsRequired();

            builder.Property(g => g.CreatedOn)                
                   .HasColumnType("datetimeoffset(0)")
                   .IsRequired();

            builder.Property(g => g.Description)
                   .IsRequired(false)
                   .HasMaxLength(255);

            builder.HasOne(g => g.GoalStatus)
                   .WithMany()
                   .HasForeignKey("_goalStatusId");

            builder.OwnsOne(g => g.AimDate);                                      
        }
    }
}
