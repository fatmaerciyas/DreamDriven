using DreamDriven.Application.Interfaces.AutoMapper;
using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.BackgroundImages.Queries.GetBackgroundImageByCategoryId
{

    public class GetBackgroundImageByCategoryIdQueryHandler : IRequestHandler<GetBackgroundImageByCategoryIdQueryRequest, IList<GetBackgroundImageByCategoryIdQueryResponse>>
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetBackgroundImageByCategoryIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetBackgroundImageByCategoryIdQueryResponse>> Handle(GetBackgroundImageByCategoryIdQueryRequest request, CancellationToken cancellationToken)
        {
            var backgroundImages = await unitOfWork.GetReadRepository<BackgroundImage>().GetAllAsync(x => x.CategoryId == request.CategoryId);

            //mapping 
            var map = mapper.Map<GetBackgroundImageByCategoryIdQueryResponse, BackgroundImage>(backgroundImages);

            return map;
        }
    }

}

