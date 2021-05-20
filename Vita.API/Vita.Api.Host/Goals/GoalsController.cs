using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Vita.Api.Application.Abstraction.Goals.Commands;
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
        public async Task<IActionResult> GetGoalsAsync(DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            if (!Guid.TryParse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value, out Guid userId))
                return Unauthorized();

            var getGoalsCreatedByUserQuery = new GetGoalsCreatedByUserQuery() { CreatedBy = userId, StartDate = startDate, EndDate = endDate };
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
        public async Task<IActionResult> CreateGoalAsync(CreateGoalCommand createGoalCommand)
        {
            if (!Guid.TryParse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value, out Guid userId))
                return Unauthorized();

            if (userId != createGoalCommand.CreatedBy)
                return Forbid();

            if (string.IsNullOrEmpty(createGoalCommand.Title))
                return BadRequest("The title cannot be empty");

            var createdGoal = await _mediator.Send(createGoalCommand);

            Response.Headers.Add("Access-Control-Allow-Headers", "Location");
            Response.Headers.Add("Access-Control-Expose-Headers", "Location");

            return CreatedAtRoute(routeName: nameof(GetGoalAsync), routeValues: new { id = createdGoal }, value: null);
        }


        [HttpPost]
        [Route("{id}/complete")]
        public async Task<IActionResult> CompleteGoalAsync(Guid id)
        {
            if (!Guid.TryParse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value, out Guid userId))
                return Unauthorized();

            var completeGoalCommand = new CompleteGoalCommand() { Id = id };
            var hasBeenCompleted = await _mediator.Send(completeGoalCommand);

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateGoalAsync(Guid id, UpdateGoalCommand updateGoalCommand)
        {
            if (!Guid.TryParse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value, out Guid userId))
                return Unauthorized();

            updateGoalCommand.Id = id;
            var hasBeenUpdated = await _mediator.Send(updateGoalCommand);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGoalAsync(Guid id)
        {
            if (!Guid.TryParse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value, out Guid userId))
                return Unauthorized();

            var deleteGoalCommand = new DeleteGoalCommand() { Id = id };
            var hasBeenDeleted = await _mediator.Send(deleteGoalCommand);

            return NoContent();
        }
    }
}