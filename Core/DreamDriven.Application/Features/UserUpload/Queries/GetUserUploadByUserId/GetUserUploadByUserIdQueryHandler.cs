using DreamDriven.Application.Interfaces.AutoMapper;
using DreamDriven.Application.Interfaces.UnitOfWorks;
using MediatR;

namespace DreamDriven.Application.Features.UserUpload.Queries.GetUserUploadByUserId
{
    public class GetUserUploadByUserIdQueryHandler : IRequestHandler<GetUserUploadByUserIdQueryRequest, IList<GetUserUploadByUserIdQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetUserUploadByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetUserUploadByUserIdQueryResponse>> Handle(GetUserUploadByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var userUpload = await unitOfWork.GetReadRepository<Domain.Entities.UserUpload>().GetAllAsync(x => x.UserId == request.UserId);

            //mapping 
            var map = mapper.Map<GetUserUploadByUserIdQueryResponse, Domain.Entities.UserUpload>(userUpload);

            return map;
        }
    }
}
