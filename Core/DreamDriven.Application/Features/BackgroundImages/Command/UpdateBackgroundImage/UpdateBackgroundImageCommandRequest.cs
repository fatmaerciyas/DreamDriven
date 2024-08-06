using MediatR;

namespace DreamDriven.Application.Features.BackgroundImages.Command.UpdateBackgroundImage
{
    public class UpdateBackgroundImageCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadedAt { get; set; }

        //Category
        public int CategoryId { get; set; }


    }
}
