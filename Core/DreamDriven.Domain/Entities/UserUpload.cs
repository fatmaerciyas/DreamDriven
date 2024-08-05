using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class UserUpload : EntityBase
    {
        public UserUpload()
        {
        }

        public UserUpload(string fileUrl, Guid userId)
        {
            FileUrl = fileUrl;
            UserId = userId;
        }

        public string FileUrl { get; set; }

        //User
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

    }
}
