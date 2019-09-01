using System.Collections.Generic;
using System.Linq;
using Vita.Domain.Categories;

namespace Vita.Application.Categories
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository CategoryRepository { get; set; }

        public CategoryService(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }        

        public IEnumerable<Category> GetAllCategories()
        {
            return CategoryRepository.GetAllCategories();
        }

        public IEnumerable<Category> GetDefaultCategories()
        {
            return CategoryRepository.GetAllCategories().Where(x => x.IsDefault);
        }

    }
}
