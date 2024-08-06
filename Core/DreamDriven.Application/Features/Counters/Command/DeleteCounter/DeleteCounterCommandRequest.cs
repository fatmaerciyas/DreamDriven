using MediatR;

namespace DreamDriven.Application.Features.Counters.Command.DeleteCounter
{
    public class DeleteCounterCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
