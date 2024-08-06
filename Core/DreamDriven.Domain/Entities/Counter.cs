using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class Counter : EntityBase
    {
        public Counter()
        {
        }

        public Counter(DateTime updated_at, Guid userId, bool is_deleted)
        {
            Updated_at = updated_at;
            UserId = userId;
            IsDeleted = is_deleted;

        }


        public DateTime Updated_at { get; set; }
        public bool IsDeleted { get; set; } = false;

        //User
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
