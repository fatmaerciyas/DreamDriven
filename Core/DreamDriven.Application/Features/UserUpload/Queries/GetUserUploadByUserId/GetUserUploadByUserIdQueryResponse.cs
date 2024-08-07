namespace DreamDriven.Application.Features.UserUpload.Queries.GetUserUploadByUserId
{
    public class GetUserUploadByUserIdQueryResponse
    {
        public string FileUrl { get; set; }
        public bool IsDeleted { get; set; }

        //User
        public Guid UserId { get; set; }

        //Category
        public int CategoryId { get; set; }
    }
}
