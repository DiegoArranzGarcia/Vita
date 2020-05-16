using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vita.Domain.Aggregates.Categories;
using Vita.Domain.Aggregates.Users;

namespace Vita.Persistance.Sql.Configurations
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

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(c => c.CreatedBy);

            //builder.HasData(GetDefaultCategories());
        }

        private Category[] GetDefaultCategories()
        {
            return new Category[]
            {
                new Category("Cooking", "skyblue"),
                new Category("Sports", "crimson"),
                new Category("VideoGames", "darkorange"),
                new Category("Travel", "lightslategray"),
                new Category("Study", "deeppink"),
                new Category("TV Series", "springgreen"),
                new Category("Movies", "turquoise"),
                new Category("Books", "darkslateblue"),
                new Category("Music", "limegreen"),
                new Category("Places", "lightseagreen"),
                new Category("Podcasts", "darkcyan"),
                new Category("Bar & Clubs", "dodgerblue"),
                new Category("Restaurants", "tomato")
            };
        }
    }
}
