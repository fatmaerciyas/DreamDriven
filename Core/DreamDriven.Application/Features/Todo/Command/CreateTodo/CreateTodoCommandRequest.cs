using MediatR;

namespace DreamDriven.Application.Features.Todo.Command.CreateTodo
{
    public class CreateTodoCommandRequest : IRequest<Unit>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime UpdatedAt { get; set; }


        //User
        public Guid UserId { get; set; }
    }
}
