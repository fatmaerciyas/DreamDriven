using MediatR;

namespace DreamDriven.Application.Features.Counters.Command.UpdateCounter
{
    public class UpdateCounterCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public DateTime Updated_at { get; set; }


    }
}
