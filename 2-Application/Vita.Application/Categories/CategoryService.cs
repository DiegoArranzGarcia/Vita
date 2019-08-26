using System.Collections.Generic;
using Vita.Domain.Categories;

namespace Vita.Application.Categories
{
    public class CategoryService : ICategoriesService
    {
        private ICategoryRepository CategoriesRepository { get; set; }

        public CategoryService(ICategoryRepository categoriesRepository)
        {
            CategoriesRepository = categoriesRepository;
        }        

        public IEnumerable<Category> GetAllCategories()
        {
            return CategoriesRepository.GetAllCategories();
        }

    }
}
