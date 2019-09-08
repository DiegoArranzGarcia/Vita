using System.Collections.Generic;
using Vita.Domain.Categories;

namespace Vita.Application.Categories.Queries
{
    public class GetAllCategoriesQuery : IGetAllCategoriesQuery
    {
        private ICategoryRepository CategoryRepository { get; set; }

        public GetAllCategoriesQuery(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public IEnumerable<Category> Execute()
        {
            return CategoryRepository.GetAllCategories();
        }
    }
}
