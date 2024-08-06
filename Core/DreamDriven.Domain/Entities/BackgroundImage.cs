using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class BackgroundImage : EntityBase
    {
        public BackgroundImage()
        {
        }

        public BackgroundImage(string fileName, string filePath, bool is_deleted, long fileSize, DateTime uploadedAt, int categoryId, int userId)
        {
            FileName = fileName;
            FilePath = filePath;
            FileSize = fileSize;
            UploadedAt = uploadedAt;
            CategoryId = categoryId;
            UserId = userId;
            IsDeleted = is_deleted;
        }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }


        //Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //User
        public int UserId { get; set; }
        public User User { get; set; }



    }
}
