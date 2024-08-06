using DreamDriven.Application.Interfaces.AutoMapper;
using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.Counters.Queries.GetAllCountersByUserId
{
    public class GetAllCountersByUserIdQueryHandler : IRequestHandler<GetAllCountersByUserIdQueryRequest, IList<GetAllCountersByUserIdQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllCountersByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllCountersByUserIdQueryResponse>> Handle(GetAllCountersByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var counters = await unitOfWork.GetReadRepository<Counter>().GetAllAsync(x => x.UserId == request.UserId);

            //mapping 
            var map = mapper.Map<GetAllCountersByUserIdQueryResponse, Counter>(counters);

            return map;
        }
    }
}

