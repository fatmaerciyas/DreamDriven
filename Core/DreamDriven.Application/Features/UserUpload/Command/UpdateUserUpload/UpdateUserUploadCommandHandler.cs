using DreamDriven.Application.Interfaces.UnitOfWorks;
using MediatR;

namespace DreamDriven.Application.Features.UserUpload.Command.UpdateUserUpload
{
    public class UpdateUserUploadCommandHandler : IRequestHandler<UpdateUserUploadCommandRequest, Unit>
    {

        private readonly IUnitOfWork unitOfWork;

        // Constructor: IUnitOfWork nesnesini alır ve sınıfın private alanına atar
        public UpdateUserUploadCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(UpdateUserUploadCommandRequest request, CancellationToken cancellationToken)
        {
            // Belirtilen ID'ye sahip ve silinmemiş UserUpload'ı al
            var userUpload = await unitOfWork.GetReadRepository<Domain.Entities.UserUpload>().GetAsync(
                x => x.Id == request.Id && !x.IsDeleted
            );

            // UserUpload mevcut değilse, bir hata fırlatıyoruz
            if ( userUpload == null )
            {
                throw new KeyNotFoundException("No UserUpload found with the specified ID.");
            }

            // UserUpload'ı güncelle
            userUpload.FileUrl = request.FileUrl;
            userUpload.IsDeleted = request.IsDeleted;


            await unitOfWork.GetWriteRepository<Domain.Entities.UserUpload>().UpdateAsync(userUpload);

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.SaveAsync(cancellationToken);

            // İşlem tamamlandığında boş döner; MediatR kullanımı için
            return Unit.Value;
        }
    }
}
