using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vita.Application.Categories.Queries;

namespace Vita.API.Categories
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IGetAllCategoriesQuery GetAllCategoriesQuery { get; set; }
        private IMapper Mapper { get; set; }

        public CategoryController(IGetAllCategoriesQuery getAllCategoriesQuery, IMapper mapper)
        {
            GetAllCategoriesQuery = getAllCategoriesQuery;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("api/categories")]
        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return Mapper.ProjectTo<CategoryDto>(GetAllCategoriesQuery.Execute().AsQueryable());
        }
    }
}