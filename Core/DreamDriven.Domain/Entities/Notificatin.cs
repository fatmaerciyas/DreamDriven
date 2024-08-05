using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class Notificatin : EntityBase
    {
        public Notificatin()
        {
        }

        public Notificatin(string message, string messageDetail, bool is_Read, Guid userId)
        {
            Message = message;
            MessageDetail = messageDetail;
            Is_Read = is_Read;
            UserId = userId;
        }

        public string Message { get; set; }
        public string MessageDetail { get; set; }
        public bool Is_Read { get; set; }

        //User
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
