using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vita.Application.Categories.Queries;

namespace Vita.API.Categories
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryQueries _categoryQueries;

        public CategoryController(ICategoryQueries CategoryQueries)
        {
            _categoryQueries = CategoryQueries;
        }

        [HttpGet]
        [Route("api/categories")]
        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            return await _categoryQueries.GetAllCategories();
        }
    }
}