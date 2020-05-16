using System.Collections.Generic;
using Vita.Domain.Categories;

namespace Vita.Persistance.InMemory
{
    public class InMemoryCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetAllCategories()
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

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
