using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Vita.Api.Application.Goals.Commands;
using Vita.Api.Application.Goals.Queries;
using Vita.Core.Pagination.Http.Headers;

namespace Vita.Api.Host.Goals
{
    [ApiController]
    [Authorize]
    [Route("api/goals")]
    public class GoalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GoalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetGoalsAsync()
        {
             if(!Guid.TryParse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value, out Guid userId))
                return Unauthorized();
                
            var getGoalsCreatedByUserQuery = new GetGoalsCreatedByUserQuery() { CreatedBy = userId };
            var goals = await _mediator.Send(getGoalsCreatedByUserQuery);

            Response.AddPaginationMetadata(goals);

            return Ok(goals);
        }

        [HttpGet]
        [Route("{id}", Name = nameof(GetGoalAsync))]
        public async Task<IActionResult> GetGoalAsync(Guid id)
        {
            var query = new GetGoalByIdQuery() { Id = id };
            var goal = await _mediator.Send(query);
            if (goal == null)
                return NotFound();

            return Ok(goal);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGoal(CreateGoalCommand createGoalCommand)
        {       
            if(!Guid.TryParse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value, out Guid userId))
                return Unauthorized();

            if (userId != createGoalCommand.CreatedBy)
                return Forbid();

            var createdGoal = await _mediator.Send(createGoalCommand);
            return CreatedAtRoute(routeName: nameof(GetGoalAsync), routeValues: new { id = createdGoal }, value: null);
        }
    }
}