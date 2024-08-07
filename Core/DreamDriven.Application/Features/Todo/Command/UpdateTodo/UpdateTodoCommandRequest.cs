using MediatR;

namespace DreamDriven.Application.Features.Todo.Command.UpdateTodo
{
    public class UpdateTodoCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
