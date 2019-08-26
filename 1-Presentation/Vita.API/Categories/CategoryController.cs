using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vita.Application.Categories;

namespace Vita.API.Categories
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoriesService CategoriesService { get; set; }
        private IMapper Mapper { get; set; }

        public CategoryController(ICategoriesService categoriesService, IMapper mapper)
        {
            CategoriesService = categoriesService;
            Mapper = mapper;
        }


        [HttpGet]
        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return Mapper.ProjectTo<CategoryDto>(CategoriesService.GetAllCategories().AsQueryable());
        }
    }
}