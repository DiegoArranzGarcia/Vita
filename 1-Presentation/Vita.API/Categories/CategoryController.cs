using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vita.Application.Categories;

namespace Vita.API.Categories
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService CategoriesService { get; set; }
        private IMapper Mapper { get; set; }

        public CategoryController(ICategoryService categoriesService, IMapper mapper)
        {
            CategoriesService = categoriesService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("api/categories")]
        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return Mapper.ProjectTo<CategoryDto>(CategoriesService.GetAllCategories().AsQueryable());
        }
    }
}