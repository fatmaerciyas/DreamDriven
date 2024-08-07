namespace DreamDriven.Application.Features.Notifications.Queries.GetAllNotifications
{
    public class GetAllNotificationsQueryResponse
    {
        public string Message { get; set; }
        public string MessageDetail { get; set; }
        public bool Is_Read { get; set; }
        public bool IsDeleted { get; set; }
        public Guid UserId { get; set; }
    }
}
