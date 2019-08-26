using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vita.Domain.Categories;

namespace Vita.Persistance.Sql.Categories
{
    public class SQLCategoryRepositoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(c => c.Color)
                   .IsRequired();

            builder.HasData(GetDefaultCategories());
        }

        private Category[] GetDefaultCategories()
        {
            return new Category[]
            {
                new Category() { Id = 1, Name = "Cooking", Color = "skyblue" },
                new Category() { Id = 2, Name = "Sports", Color = "crimson" },
                new Category() { Id = 3, Name = "VideoGames", Color = "darkorange" },
                new Category() { Id = 4, Name = "Travel", Color = "lightslategray" },
                new Category() { Id = 5, Name = "Study", Color = "deeppink" },
                new Category() { Id = 6, Name = "TV Series", Color = "springgreen" },
                new Category() { Id = 7, Name = "Movies", Color = "turquoise" },
                new Category() { Id = 8, Name = "Books", Color = "darkslateblue" },
                new Category() { Id = 9, Name = "Music", Color = "limegreen" },
                new Category() { Id = 10, Name = "Places", Color = "lightseagreen" },
                new Category() { Id = 11, Name = "Podcasts", Color = "darkcyan" },
                new Category() { Id = 12, Name = "Bar & Clubs", Color = "dodgerblue" },
                new Category() { Id = 13, Name = "Restaurants", Color = "tomato" },
            };
        }
    }
}
