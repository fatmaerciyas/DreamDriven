using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class CounterLog : EntityBase
    {

        public CounterLog() { }

        public CounterLog(DateTime startTime, DateTime? endTime, TimeSpan? duration, int counterId)
        {
            StartTime = startTime;
            EndTime = endTime;
            Duration = duration;
            CounterId = counterId;
        }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? Duration { get; set; }

        //User
        public int CounterId { get; set; }
        public Counter Counter { get; set; }
    }
}
