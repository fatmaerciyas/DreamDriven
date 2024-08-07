using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class Notification : EntityBase
    {
        public Notification()
        {
        }

        public Notification(string message, string messageDetail, bool is_Read, Guid userId, bool isDeleted = false)
        {
            Message = message;
            MessageDetail = messageDetail;
            Is_Read = is_Read;
            UserId = userId;
            IsDeleted = isDeleted;
            IsDeleted = isDeleted;
        }

        public string Message { get; set; }
        public string MessageDetail { get; set; }
        public bool Is_Read { get; set; }
        public bool IsDeleted { get; set; }


        //User
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
