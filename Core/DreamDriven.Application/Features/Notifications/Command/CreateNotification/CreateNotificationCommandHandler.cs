using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;


namespace DreamDriven.Application.Features.Notifications.Command.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateNotificationCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateNotificationCommandRequest request, CancellationToken cancellationToken)
        {
            Guid newGuid = Guid.NewGuid();

            // Yeni Notification nesnesini oluştur
            var notification = new Notification(
                   request.Message,
                   request.MessageDetail,
                   false,
                   newGuid,
                   false

                  );

            // Notification nesnesini ekle
            await unitOfWork.GetWriteRepository<Notification>().AddAsync(notification);


            // Değişiklikleri kaydet
            await unitOfWork.SaveAsync(cancellationToken);

            // Boş dönmemizi sağlıyoruz; pipeline'ın doğru çalışması için
            return Unit.Value;
        }
    }
}
