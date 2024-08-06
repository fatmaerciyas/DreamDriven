using MediatR;

namespace DreamDriven.Application.Features.CounterLog.Command.CreateCounterLog
{
    public class CreateCounterLogCommandRequest : IRequest<Unit>
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? Duration { get; set; }

        //User
        public int CounterId { get; set; }
    }
}
