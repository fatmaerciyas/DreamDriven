using MediatR;

namespace DreamDriven.Application.Features.Categories.Command.DeleteFolder
{
    public class DeleteCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}
