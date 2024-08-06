using DreamDriven.Application.Interfaces.AutoMapper;
using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.Categories.Queries.GettAllCategories
{

    // sadece request de verebilirim request,response da verebilirim. Veri donmek istiyorsam response vermeliyim
    public class GettAllCategoriesQueryHandler : IRequestHandler<GettAllCategoriesQueryRequest, IList<GettAllCategoriesQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GettAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GettAllCategoriesQueryResponse>> Handle(GettAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync(); //include: x => x.Include(b => b.Visuals)


            //mapping
            var map = mapper.Map<GettAllCategoriesQueryResponse, Category>(categories);
            return map;

        }
    }
}
