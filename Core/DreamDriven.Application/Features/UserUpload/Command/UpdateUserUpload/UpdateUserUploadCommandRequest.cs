using MediatR;

namespace DreamDriven.Application.Features.UserUpload.Command.UpdateUserUpload
{
    public class UpdateUserUploadCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string FileUrl { get; set; }
        public bool IsDeleted { get; set; }
    }
}
