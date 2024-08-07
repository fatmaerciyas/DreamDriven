using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class Counter : EntityBase
    {

        public Counter() { }

        public Counter(DateTime startTime, DateTime? endTime, TimeSpan? duration, bool is_deleted, Guid userId, DateTime? updated_at = null)
        {
            StartTime = startTime;
            EndTime = endTime;
            Duration = duration;
            UserId = userId;
            Updated_at = updated_at;
            IsDeleted = is_deleted;

        }


        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public DateTime? Updated_at { get; set; }
        public bool IsDeleted { get; set; } = false;

        //User
        public Guid UserId { get; set; }
        public User User { get; set; }

        ////Counter
        //public int CounterId { get; set; }
        //public Counter Counter { get; set; }
    }
}
