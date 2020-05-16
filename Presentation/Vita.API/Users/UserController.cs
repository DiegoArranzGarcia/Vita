using Microsoft.AspNetCore.Mvc;
using Vita.Application.Users.Commands;
using MediatR;
using System.Threading.Tasks;
using Vita.Application.Users.Queries;
using System;

namespace Vita.API.Users
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserQueries _userQueries;

        public UserController(IMediator mediator, IUserQueries userQueries)
        {
            _mediator = mediator;
            _userQueries = userQueries;
        }

        [HttpGet]
        [Route("{id}", Name = nameof(GetUserAsync))]
        public async Task<IActionResult> GetUserAsync(Guid id)
        {
            var user = await _userQueries.GetUserByIdAsync(id);

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
