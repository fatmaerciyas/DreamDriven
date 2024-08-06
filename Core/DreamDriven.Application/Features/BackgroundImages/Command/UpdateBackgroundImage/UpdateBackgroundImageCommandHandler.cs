using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.BackgroundImages.Command.UpdateBackgroundImage
{
    public class UpdateBackgroundImageCommandHandler : IRequestHandler<UpdateBackgroundImageCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        // Constructor: IUnitOfWork nesnesini alır ve sınıfın private alanına atar
        public UpdateBackgroundImageCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        // Handle metodunu async olarak tanımlıyoruz
        public async Task<Unit> Handle(UpdateBackgroundImageCommandRequest request, CancellationToken cancellationToken)
        {
            // Belirtilen ID'ye sahip ve silinmemiş BackgroundImage'ı al
            var backgroundImage = await unitOfWork.GetReadRepository<BackgroundImage>().GetAsync(
                x => x.Id == request.Id && !x.IsDeleted
            );

            // BackgroundImage mevcut değilse, bir hata fırlatıyoruz
            if ( backgroundImage == null )
            {
                throw new KeyNotFoundException("No BackgroundImage found with the specified ID.");
            }

            // BackgroundImage'ı güncelle
            backgroundImage.FilePath = request.FilePath;
            backgroundImage.FileName = request.FileName;
            backgroundImage.FileSize = request.FileSize;
            backgroundImage.UploadedAt = DateTime.Now;
            backgroundImage.CategoryId = request.CategoryId;

            await unitOfWork.GetWriteRepository<BackgroundImage>().UpdateAsync(backgroundImage);

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.SaveAsync(cancellationToken);

            // İşlem tamamlandığında boş döner; MediatR kullanımı için
            return Unit.Value;
        }
    }
}
