using MediatR;

namespace DreamDriven.Application.Features.Notifications.Command.DeleteNotification
{
    public class DeleteNotificationCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
