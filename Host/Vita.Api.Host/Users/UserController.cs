using Microsoft.AspNetCore.Mvc;
using Vita.Application.Users.Commands;
using MediatR;
using System.Threading.Tasks;
using System;
using Vita.Application.Users.Queries;

namespace Vita.API.Users
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}", Name = nameof(GetUserAsync))]
        public async Task<IActionResult> GetUserAsync(GetUserByIdQuery query)
        {
            var user = await _mediator.Send(query);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(CreateUserCommand createUserCommand)
        {
            var createdUser = await _mediator.Send(createUserCommand);
            return CreatedAtRoute(routeName: nameof(GetUserAsync), routeValues: new { id = createdUser }, value: null );
        }
    }
}
