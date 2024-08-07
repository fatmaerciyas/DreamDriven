using MediatR;

namespace DreamDriven.Application.Features.Counters.Command.UpdateCounter
{
    public class UpdateCounterCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
