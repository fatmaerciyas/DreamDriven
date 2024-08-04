using MediatR;

namespace DreamDriven.Application.Features.Categories.Command.DeleteFolder
{
    public class DeleteCategoryCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
