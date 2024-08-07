using MediatR;

namespace DreamDriven.Application.Features.Notifications.Queries.GetAllNotifications
{
    public class GetAllNotificationsQueryRequest : IRequest<IList<GetAllNotificationsQueryResponse>> // response birden cok veri ise List kullan
    {
    }
}
