using DreamDriven.Application.Features.UserUpload.Command.CreateUserUpload;
using DreamDriven.Application.Features.UserUpload.Command.DeleteUserUpload;
using DreamDriven.Application.Features.UserUpload.Command.UpdateUserUpload;
using DreamDriven.Application.Features.UserUpload.Queries.GetUserUploadByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DreamDriven.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserUploadController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserUploadController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBackgroungImages(GetUserUploadByUserIdQueryRequest request) // GetAllCategories(GettAllCategoriesQueryRequest request)
        {

            var response = await mediator.Send(request); //herhangi bir querye gore donmek istemedigim icin boyle yoksa // Send( request )

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserUpload(CreateUserUploadCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserUpload(UpdateUserUploadCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserUpload(DeleteUserUploadCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }


    }
}
