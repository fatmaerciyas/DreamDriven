using DreamDriven.Application.Interfaces.AutoMapper;
using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.Notifications.Queries.GetAllNotifications
{
    public class GetAllNotificationsQueryHandler : IRequestHandler<GetAllNotificationsQueryRequest, IList<GetAllNotificationsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllNotificationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }



        public async Task<IList<GetAllNotificationsQueryResponse>> Handle(GetAllNotificationsQueryRequest request, CancellationToken cancellationToken)
        {
            // Await the asynchronous call to get the list of notifications
            var notifications = await unitOfWork.GetReadRepository<Notification>().GetAllAsync();

            // Map the list of notifications to the response objects
            var response = mapper.Map<IList<GetAllNotificationsQueryResponse>>(notifications);

            return response;
        }

    }
}
