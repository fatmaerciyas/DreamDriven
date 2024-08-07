using DreamDriven.Application.Features.Todo.Command.CreateTodo;
using DreamDriven.Application.Features.Todo.Command.DeleteTodo;
using DreamDriven.Application.Features.Todo.Command.UpdateTodo;
using DreamDriven.Application.Features.Todo.Queries.GetTodosByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DreamDriven.API.Controllers
{
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
        public async Task<IActionResult> GetTodoBy(GetTodosByUserIdQueryRequest request) // GetAllCategories(GettAllCategoriesQueryRequest request)
        {

            var response = await mediator.Send(request); //herhangi bir querye gore donmek istemedigim icin boyle yoksa // Send( request )

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo(CreateTodoCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTodo(UpdateTodoCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTodo(DeleteTodoCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

    }
}
