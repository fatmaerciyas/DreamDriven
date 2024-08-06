using MediatR;

namespace DreamDriven.Application.Features.BackgroundImages.Command.DeleteBackgroundImage
{
    public class DeleteBackgroundImageCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
