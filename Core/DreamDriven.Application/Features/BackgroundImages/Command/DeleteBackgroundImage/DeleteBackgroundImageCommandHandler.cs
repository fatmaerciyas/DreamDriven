using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.BackgroundImages.Command.DeleteBackgroundImage
{
    public class DeleteBackgroundImageCommandHandler : IRequestHandler<DeleteBackgroundImageCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        // Constructor: IUnitOfWork nesnesini alır ve sınıfın private alanına atar
        public DeleteBackgroundImageCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(DeleteBackgroundImageCommandRequest request, CancellationToken cancellationToken)
        {
            // Belirtilen ID'ye sahip ve silinmemiş background image'i al
            var backgroundImage = await unitOfWork.GetReadRepository<BackgroundImage>().GetAsync(
                x => x.Id == request.Id && !x.IsDeleted
            );

            // BackgroundImage mevcut değilse, bir hata fırlatıyoruz
            if ( backgroundImage == null )
            {
                throw new KeyNotFoundException("No background image found with the specified ID.");
            }

            // BackgroundImage'i silinmiş olarak işaretle
            backgroundImage.IsDeleted = true;

            // BackgroundImage'i güncelle
            await unitOfWork.GetWriteRepository<BackgroundImage>().UpdateAsync(backgroundImage);

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.SaveAsync(cancellationToken);

            // İşlem tamamlandığında boş döner; MediatR kullanımı için
            return Unit.Value;
        }
    }
}
