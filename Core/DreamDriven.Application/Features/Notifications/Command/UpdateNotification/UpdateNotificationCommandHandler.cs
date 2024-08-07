using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.Notifications.Command.UpdateNotification
{
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        // Constructor: IUnitOfWork nesnesini alır ve sınıfın private alanına atar
        public UpdateNotificationCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        // Handle metodunu async olarak tanımlıyoruz
        public async Task<Unit> Handle(UpdateNotificationCommandRequest request, CancellationToken cancellationToken)
        {
            // Belirtilen ID'ye sahip ve silinmemiş Notification'ı al
            var notification = await unitOfWork.GetReadRepository<Notification>().GetAsync(
                x => x.Id == request.Id && !x.IsDeleted
            );

            // Notification mevcut değilse, bir hata fırlatıyoruz
            if ( notification == null )
            {
                throw new KeyNotFoundException("No Notification found with the specified ID.");
            }

            // Notification'ı güncelle
            notification.Message = request.Message;
            notification.MessageDetail = request.MessageDetail;
            notification.IsDeleted = request.IsDeleted;
            notification.Is_Read = request.Is_Read;


            await unitOfWork.GetWriteRepository<Notification>().UpdateAsync(notification);

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.SaveAsync(cancellationToken);

            // İşlem tamamlandığında boş döner; MediatR kullanımı için
            return Unit.Value;
        }
    }
}
