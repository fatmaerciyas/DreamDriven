using MediatR;

namespace DreamDriven.Application.Features.Counters.Command.CreateCounter
{
    public class CreateCounterCommandRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public DateTime Updated_at { get; set; }

        //User
        public Guid UserId { get; set; }
    }
}
