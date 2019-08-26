﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vita.Persistance.Sql;

namespace Vita.Persistance.Sql.Migrations
{
    [DbContext(typeof(VitaDbContext))]
    partial class VitaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vita.Domain.Categories.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Color = "skyblue",
                            Name = "Cooking"
                        },
                        new
                        {
                            Id = 2L,
                            Color = "crimson",
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 3L,
                            Color = "darkorange",
                            Name = "VideoGames"
                        },
                        new
                        {
                            Id = 4L,
                            Color = "lightslategray",
                            Name = "Travel"
                        },
                        new
                        {
                            Id = 5L,
                            Color = "deeppink",
                            Name = "Study"
                        },
                        new
                        {
                            Id = 6L,
                            Color = "springgreen",
                            Name = "TV Series"
                        },
                        new
                        {
                            Id = 7L,
                            Color = "turquoise",
                            Name = "Movies"
                        },
                        new
                        {
                            Id = 8L,
                            Color = "darkslateblue",
                            Name = "Books"
                        },
                        new
                        {
                            Id = 9L,
                            Color = "limegreen",
                            Name = "Music"
                        },
                        new
                        {
                            Id = 10L,
                            Color = "lightseagreen",
                            Name = "Places"
                        },
                        new
                        {
                            Id = 11L,
                            Color = "darkcyan",
                            Name = "Podcasts"
                        },
                        new
                        {
                            Id = 12L,
                            Color = "dodgerblue",
                            Name = "Bar & Clubs"
                        },
                        new
                        {
                            Id = 13L,
                            Color = "tomato",
                            Name = "Restaurants"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
