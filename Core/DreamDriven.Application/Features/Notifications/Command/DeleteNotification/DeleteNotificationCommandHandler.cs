using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.Notifications.Command.DeleteNotification
{
    public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteNotificationCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteNotificationCommandRequest request, CancellationToken cancellationToken)
        {
            // Belirtilen ID'ye sahip ve silinmemiş background image'i al
            var notification = await unitOfWork.GetReadRepository<Notification>().GetAsync(
                x => x.Id == request.Id && !x.IsDeleted
            );

            // Notification mevcut değilse, bir hata fırlatıyoruz
            if ( notification == null )
            {
                throw new KeyNotFoundException("No background image found with the specified ID.");
            }

            // Notification'i silinmiş olarak işaretle
            notification.IsDeleted = true;

            // Notification'i güncelle
            await unitOfWork.GetWriteRepository<Notification>().UpdateAsync(notification);

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.SaveAsync(cancellationToken);

            // İşlem tamamlandığında boş döner; MediatR kullanımı için
            return Unit.Value;
        }
    }
}
