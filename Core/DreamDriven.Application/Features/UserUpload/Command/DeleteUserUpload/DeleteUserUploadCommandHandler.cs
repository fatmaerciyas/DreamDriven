using DreamDriven.Application.Interfaces.UnitOfWorks;
using MediatR;

namespace DreamDriven.Application.Features.UserUpload.Command.DeleteUserUpload
{
    public class DeleteUserUploadCommandHandler : IRequestHandler<DeleteUserUploadCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        // Constructor: IUnitOfWork nesnesini alır ve sınıfın private alanına atar
        public DeleteUserUploadCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(DeleteUserUploadCommandRequest request, CancellationToken cancellationToken)
        {
            // Belirtilen ID'ye sahip ve silinmemiş counter'ı al
            var userUpload = await unitOfWork.GetReadRepository<Domain.Entities.UserUpload>().GetAsync(
                 x => x.Id == request.Id && !x.IsDeleted
            );

            // Counter mevcut değilse, bir hata fırlatıyoruz
            if ( userUpload == null )
            {
                throw new KeyNotFoundException("No UserUpload found with the specified ID.");
            }


            // Counter'ı silinmiş olarak işaretle
            userUpload.IsDeleted = true;

            // Counter'ı güncelle
            await unitOfWork.GetWriteRepository<Domain.Entities.UserUpload>().UpdateAsync(userUpload);

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.SaveAsync(cancellationToken);

            // İşlem tamamlandığında boş döner; MediatR kullanımı için
            return Unit.Value;
        }
    }
}
