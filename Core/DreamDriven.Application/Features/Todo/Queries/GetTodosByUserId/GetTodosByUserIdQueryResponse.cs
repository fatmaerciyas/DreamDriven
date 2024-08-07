using DreamDriven.Domain.Entities;

namespace DreamDriven.Application.Features.Todo.Queries.GetTodosByUserId
{
    public class GetTodosByUserIdQueryResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime UpdatedAt { get; set; }


        //User
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
