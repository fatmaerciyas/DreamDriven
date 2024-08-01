using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class WeeklyMonthlyPlan : EntityBase
    {
        public string PlanTitle { get; set; }
        public string PlanDetail { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? EndedDate { get; set; }

        //user
        public Guid? UserId { get; set; }
        public User User { get; set; }
    }
}
