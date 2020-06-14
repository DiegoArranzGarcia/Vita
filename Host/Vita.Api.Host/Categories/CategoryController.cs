using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vita.Api.Application.Categories.Commands;
using Vita.Api.Application.Categories.Queries;
using Vita.Core.Pagination.Http.Headers;

namespace Vita.Api.Host.Categories
{
    [ApiController]
    [Authorize]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var getCategoriesCreatedByUserQuery = new GetCategoriesCreatedByUserQuery() { CreatedBy = new Guid("40ff4a45-35b0-4897-6fd6-08d7f97a645b") };
            var categories = await _mediator.Send(getCategoriesCreatedByUserQuery);

            Response.AddPaginationMetadata(categories);

            return categories;
        }

        [HttpGet]
        [Route("{id}", Name = nameof(GetCategoryAsync))]
        public async Task<IActionResult> GetCategoryAsync(GetCategoryByIdQuery query)
        {
            var category = await _mediator.Send(query);
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