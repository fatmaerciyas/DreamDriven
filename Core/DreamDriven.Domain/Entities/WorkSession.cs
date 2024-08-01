using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public enum TimerType
    {
        Work,
        Break
    }

    public class WorkSession : EntityBase
    {

        public TimerType Type { get; set; } // Çalışma veya mola türü
        public TimeSpan Duration { get; set; } // Süre (çalışma süresi veya mola süresi)
        public DateTime? EndTime
        {
            get; set;
        } // Bitiş zamanı (null olabilir)
        public bool IsActive { get; set; }

        //  user
        public Guid UserId { get; set; }
        public User User { get; set; }
    }

}
