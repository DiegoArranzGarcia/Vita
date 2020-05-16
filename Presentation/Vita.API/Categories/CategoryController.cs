using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vita.Application.Categories.Commands;
using Vita.Application.Categories.Queries;

namespace Vita.API.Categories
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryQueries _categoryQueries;
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator, ICategoryQueries CategoryQueries)
        {
            _categoryQueries = CategoryQueries;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            return await _categoryQueries.GetAllCategoriesCreatedByUser(new Guid("40ff4a45-35b0-4897-6fd6-08d7f97a645b"));
        }

        [HttpGet]
        [Route("{id}", Name = nameof(GetCategoryAsync))]
        public async Task<IActionResult> GetCategoryAsync(Guid id)
        {
            var category = await _categoryQueries.GetCategory(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            var createdCategory = await _mediator.Send(createCategoryCommand);
            return CreatedAtRoute(routeName: nameof(GetCategoryAsync), routeValues: new { id = createdCategory }, value: null);
        }
    }
}