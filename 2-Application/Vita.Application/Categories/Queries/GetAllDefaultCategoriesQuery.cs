using System.Collections.Generic;
using System.Linq;
using Vita.Domain.Categories;

namespace Vita.Application.Categories.Queries
{
    public class GetAllDefaultCategoriesQuery : IGetAllDefaultCategoriesQuery
    {
        private ICategoryRepository CategoryRepository { get; set; }

        public GetAllDefaultCategoriesQuery(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public IEnumerable<Category> Execute()
        {
            return CategoryRepository.GetAllCategories().Where(x => x.IsDefault);
        }
    }
}
