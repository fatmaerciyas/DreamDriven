using MediatR;

namespace DreamDriven.Application.Features.BackgroundImages.Queries.GetBackgroundImageByCategoryId
{
    public class GetBackgroundImageByCategoryIdQueryRequest : IRequest<IList<GetBackgroundImageByCategoryIdQueryResponse>> // response birden cok veri ise List kullan
    {

        //Category
        public int CategoryId { get; set; }

    }
}
