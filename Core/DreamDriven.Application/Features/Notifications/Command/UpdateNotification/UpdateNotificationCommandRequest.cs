using MediatR;

namespace DreamDriven.Application.Features.Notifications.Command.UpdateNotification
{
    public class UpdateNotificationCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }
        public bool Is_Read { get; set; }
        public bool IsDeleted { get; set; }
    }
}
