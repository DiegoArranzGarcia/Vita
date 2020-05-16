using Microsoft.AspNetCore.Mvc;
using Vita.Application.Users.Commands;
using MediatR;
using System.Threading.Tasks;
using Vita.Application.Users.Queries;
using System;

namespace Vita.API.Users
{
    [ApiController]
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
        [Route("api/users/{id}")]
        public async Task<IActionResult> GetUserAsync(Guid id)
        {
            var user = await _userQueries.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [Route("api/users", Name="CreateUser")]
        public async Task<IActionResult> CreateUserAsync(CreateUserCommand createUserCommand)
        {
            var hasBeenCreated = await _mediator.Send<bool>(createUserCommand);
            return Ok();
        }
    }
}
