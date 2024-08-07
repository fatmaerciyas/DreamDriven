using MediatR;

namespace DreamDriven.Application.Features.Notifications.Command.CreateNotification
{
    // Bir notofication olusturuken ihtiyacim olan ozellikler
    public class CreateNotificationCommandRequest : IRequest<Unit>
    {
        public string Message { get; set; }
        public string MessageDetail { get; set; }
        public bool Is_Read { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public Guid UserId { get; set; }
    }
}
