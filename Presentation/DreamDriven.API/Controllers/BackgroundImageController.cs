using DreamDriven.Application.Features.BackgroundImages.Command.CreateBackgroundImage;
using DreamDriven.Application.Features.BackgroundImages.Command.DeleteBackgroundImage;
using DreamDriven.Application.Features.BackgroundImages.Command.UpdateBackgroundImage;
using DreamDriven.Application.Features.BackgroundImages.Queries.GetBackgroundImageByCategoryId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DreamDriven.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BackgroundImageController : ControllerBase
    {
        private readonly IMediator mediator;

        public BackgroundImageController(IMediator mediator)
        {
            this.mediator = mediator;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllBackgroundImages(GetBackgroundImageByCategoryIdQueryRequest request) // GetAllCategories(GettAllCategoriesQueryRequest request)
        {

            var response = await mediator.Send(request); //herhangi bir querye gore donmek istemedigim icin boyle yoksa // Send( request )

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBackgroundImages(CreateBackgroundImageCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBackgroundImages(UpdateBackgroundImageCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBackgroundImages(DeleteBackgroundImageCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }
    }
}
