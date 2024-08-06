using MediatR;

namespace DreamDriven.Application.Features.Counters.Queries.GetAllCountersByUserId
{
    public class GetAllCountersByUserIdQueryRequest : IRequest<IList<GetAllCountersByUserIdQueryResponse>>
    {
        public Guid UserId { get; set; }

    }
}
