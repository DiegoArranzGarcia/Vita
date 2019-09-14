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
        private IGetAllCategoriesOfUserQuery GetAllCategoriesOfUserQuery { get; set; }
        private IMapper Mapper { get; set; }

        public CategoryController(IGetAllCategoriesQuery getAllCategoriesQuery,
                                  IGetAllCategoriesOfUserQuery getAllCategoriesOfUserQuery,
                                  IMapper mapper)
        {
            GetAllCategoriesQuery = getAllCategoriesQuery;
            GetAllCategoriesOfUserQuery = getAllCategoriesOfUserQuery;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("api/categories")]
        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return Mapper.ProjectTo<CategoryDto>(GetAllCategoriesQuery.Execute().AsQueryable());
        }

        [HttpGet]
        [Route("api/users/{userId}/categories")]
        public IEnumerable<CategoryDto> GetUserCategories(long userId)
        {
            return Mapper.ProjectTo<CategoryDto>(GetAllCategoriesOfUserQuery.Execute(userId).AsQueryable());
        }
    }
}