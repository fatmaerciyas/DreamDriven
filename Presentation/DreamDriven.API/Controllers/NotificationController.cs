using DreamDriven.Application.Features.Notifications.Command.CreateNotification;
using DreamDriven.Application.Features.Notifications.Command.DeleteNotification;
using DreamDriven.Application.Features.Notifications.Command.UpdateNotification;
using DreamDriven.Application.Features.Notifications.Queries.GetAllNotifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DreamDriven.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator mediator;

        public NotificationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotifications() // GetAllCategories(GettAllCategoriesQueryRequest request)
        {

            var response = await mediator.Send(new GetAllNotificationsQueryRequest()); //herhangi bir querye gore donmek istemedigim icin boyle yoksa // Send( request )

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteNotification(DeleteNotificationCommandRequest request)
        {

            await mediator.Send(request);
            return Ok();
        }

    }
}
