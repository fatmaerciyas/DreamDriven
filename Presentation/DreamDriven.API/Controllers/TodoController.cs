using DreamDriven.Application.Features.Todo.Command.CreateTodo;
using DreamDriven.Application.Features.Todo.Command.DeleteTodo;
using DreamDriven.Application.Features.Todo.Command.UpdateTodo;
using DreamDriven.Application.Features.Todo.Queries.GetTodosByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DreamDriven.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator mediator;

        public TodoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodoBy([FromQuery] Guid userId)
        {
            if ( userId == Guid.Empty )
            {
                return BadRequest("Invalid User ID");
            }

            var request = new GetTodosByUserIdQueryRequest
            {
                UserId = userId
            };

            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoCommandRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if ( userId == null )
            {
                return BadRequest("Invalid User ID");
            }

            Guid userIdGuid = Guid.Parse(userId);

            request.UserId = userIdGuid;

            await mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTodo([FromBody] UpdateTodoCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTodo([FromBody] DeleteTodoCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


    }
}
