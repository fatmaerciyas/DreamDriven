using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class Todo : EntityBase
    {
        public Todo()
        {
        }

        public Todo(string title, string description, DateTime? dueDate, bool isCompleted, DateTime updatedAt, Guid userId)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsCompleted = isCompleted;
            UpdatedAt = updatedAt;
            UserId = userId;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime UpdatedAt { get; set; }


        //User
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
