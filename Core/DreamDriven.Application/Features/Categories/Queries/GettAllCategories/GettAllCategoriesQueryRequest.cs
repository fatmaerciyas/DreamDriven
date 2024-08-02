using MediatR;

namespace DreamDriven.Application.Features.Categories.Queries.GettAllCategories
{
    public class GettAllCategoriesQueryRequest : IRequest<IList<GettAllCategoriesQueryResponse>> // response birden cok veri ise List kullan
    {
    }
}
