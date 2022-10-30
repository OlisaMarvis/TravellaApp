using MediatR;
using Application.Features.UserFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.UserFeatures.Commands.DeleteUser;
using Application.Features.UserFeatures.Commands.CreateUser;
using Application.Features.UserFeatures.Commands.UpdateUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TravellaWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }

        [HttpPost]
        [Route("{CreateUser}")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{userId}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            var result = await _mediator.Send(new GetUserByIdQuery
            {
                Id = userId
            });
            return Ok(result);
        }

        [HttpDelete("{userId}", Name = "DeleteUser")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var result = await _mediator.Send(new DeleteUserByIdCommand
            {
                UserId = userId
            });
            return Ok(result);
        }

        [HttpPut("{UserId}", Name = "UpdateUser")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateUserCommand command, Guid userId)
        {
            if (userId == command.UserId) return NoContent();
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
