using MediatR;

namespace DreamDriven.Application.Features.UserUpload.Command.DeleteUserUpload
{
    public class DeleteUserUploadCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
