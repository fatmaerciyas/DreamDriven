using MediatR;

namespace DreamDriven.Application.Features.UserUpload.Command.CreateUserUpload
{
    public class CreateUserUploadCommandRequest : IRequest<Unit>
    {

        public string FileUrl { get; set; }
        public bool IsDeleted { get; set; }

        //User
        public Guid UserId { get; set; }

        //Category
        public int CategoryId { get; set; }
    }
}
