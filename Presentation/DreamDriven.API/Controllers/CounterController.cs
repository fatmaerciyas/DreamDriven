using DreamDriven.Application.Features.Counters.Command.CreateCounter;
using DreamDriven.Application.Features.Counters.Command.DeleteCounter;
using DreamDriven.Application.Features.Counters.Command.UpdateCounter;
using DreamDriven.Application.Features.Counters.Queries.GetAllCountersByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DreamDriven.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly IMediator mediator;

        public CounterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCounterByUserId(GetAllCountersByUserIdQueryRequest request) // GetAllCategories
        {

            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCounter(CreateCounterCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCounter(UpdateCounterCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCounter(DeleteCounterCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }
    }
}
