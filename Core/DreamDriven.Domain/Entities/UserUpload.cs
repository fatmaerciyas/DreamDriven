using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class UserUpload : EntityBase
    {
        public UserUpload()
        {
        }

        public UserUpload(string fileUrl, Guid userId, bool isDeleted, int category_Id)
        {
            FileUrl = fileUrl;
            UserId = userId;
            IsDeleted = isDeleted;
            CategoryId = category_Id;
        }

        public string FileUrl { get; set; }
        public bool IsDeleted { get; set; }

        //User
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        //Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
