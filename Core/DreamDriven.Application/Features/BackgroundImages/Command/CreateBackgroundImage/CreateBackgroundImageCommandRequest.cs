using MediatR;

namespace DreamDriven.Application.Features.BackgroundImages.Command.CreateBackgroundImage
{

    //BackgroundImage olustururken ihtiyacım olan ozellikler
    public class CreateBackgroundImageCommandRequest : IRequest<Unit>
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadedAt { get; set; }


        //Category
        public int CategoryId { get; set; }

        //User
        public int UserId { get; set; }
    }
}
