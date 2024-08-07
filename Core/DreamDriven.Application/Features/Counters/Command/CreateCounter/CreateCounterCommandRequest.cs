using MediatR;

namespace DreamDriven.Application.Features.Counters.Command.CreateCounter
{
    public class CreateCounterCommandRequest : IRequest<Unit>
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public bool IsDeleted { get; set; } = false;

        //User
        public Guid UserId { get; set; }



    }
}
