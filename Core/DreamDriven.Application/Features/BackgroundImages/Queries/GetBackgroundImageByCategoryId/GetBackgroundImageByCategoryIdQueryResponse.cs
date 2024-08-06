namespace DreamDriven.Application.Features.BackgroundImages.Queries.GetBackgroundImageByCategoryId
{
    public class GetBackgroundImageByCategoryIdQueryResponse
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.Now;


        //Category
        public int CategoryId { get; set; }

        //User
        public int UserId { get; set; }
    }
}
