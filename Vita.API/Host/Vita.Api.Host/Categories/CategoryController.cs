using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public async Task<IActionResult> GetCategoriesAsync()
        {
            if(!Guid.TryParse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value, out Guid userId))
                return Unauthorized();
                
            var getCategoriesCreatedByUserQuery = new GetCategoriesCreatedByUserQuery() { CreatedBy = userId };
            var categories = await _mediator.Send(getCategoriesCreatedByUserQuery);

            Response.AddPaginationMetadata(categories);

            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}", Name = nameof(GetCategoryAsync))]
        public async Task<IActionResult> GetCategoryAsync(Guid id)
        {
            var query = new GetCategoryByIdQuery() { Id = id };
            var category = await _mediator.Send(query);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            if(!Guid.TryParse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value, out Guid userId))
                return Unauthorized();

           if (userId != createCategoryCommand.CreatedBy)
                return Forbid();

            var createdCategory = await _mediator.Send(createCategoryCommand);
            return CreatedAtRoute(routeName: nameof(GetCategoryAsync), routeValues: new { id = createdCategory }, value: null);
        }
    }
}