using DreamDriven.Application.Interfaces.AutoMapper;
using DreamDriven.Application.Interfaces.UnitOfWorks;
using MediatR;

namespace DreamDriven.Application.Features.Todo.Queries.GetTodosByUserId
{
    public class GetTodosByUserIdQueryHandler : IRequestHandler<GetTodosByUserIdQueryRequest, IList<GetTodosByUserIdQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetTodosByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetTodosByUserIdQueryResponse>> Handle(GetTodosByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var todos = await unitOfWork.GetReadRepository<Domain.Entities.Todo>().GetAllAsync(x => x.UserId == request.UserId);

            //mapping 
            var map = mapper.Map<GetTodosByUserIdQueryResponse, Domain.Entities.Todo>(todos);

            return map;
        }
    }
}
