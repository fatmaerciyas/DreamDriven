using MediatR;

namespace DreamDriven.Application.Features.Todo.Command.DeleteTodo
{
    public class DeleteTodoCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
