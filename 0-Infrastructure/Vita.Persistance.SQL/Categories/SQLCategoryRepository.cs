using System.Collections.Generic;
using Vita.Persistance.Sql;
using Vita.Domain.Categories;

namespace Vita.Persistance.Categories
{
    public class SQLCategoryRepository : ICategoryRepository
    {
        private VitaDbContext VitaDbContext { get; set; }

        public SQLCategoryRepository(VitaDbContext vitaDbContext)
        {
            VitaDbContext = vitaDbContext;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return VitaDbContext.Categories;
        }

        public void Save()
        {
            VitaDbContext.SaveChanges();
        }
    }
}
