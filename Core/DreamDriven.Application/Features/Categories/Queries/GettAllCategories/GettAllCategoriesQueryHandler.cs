using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.Categories.Queries.GettAllCategories
{

    // sadece request de verebilirim request,response da verebilirim. Veri donmek istiyorsam response vermeliyim
    public class GettAllCategoriesQueryHandler : IRequestHandler<GettAllCategoriesQueryRequest, IList<GettAllCategoriesQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GettAllCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GettAllCategoriesQueryResponse>> Handle(GettAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync();

            //MAPPİNG

        }
    }
}
