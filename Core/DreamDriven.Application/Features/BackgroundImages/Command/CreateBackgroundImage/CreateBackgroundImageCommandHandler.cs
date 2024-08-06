using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.BackgroundImages.Command.CreateBackgroundImage
{
    public class CreateBackgroundImageCommandHandler : IRequestHandler<CreateBackgroundImageCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateBackgroundImageCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateBackgroundImageCommandRequest request, CancellationToken cancellationToken)
        {
            // Yeni BackgroundImage nesnesini oluştur
            var backgroundImage = new BackgroundImage(
                request.FileName,
                request.FilePath,
                false,
                request.FileSize,
                request.UploadedAt,
                request.CategoryId,
                request.UserId);

            // BackgroundImage nesnesini ekle
            await unitOfWork.GetWriteRepository<BackgroundImage>().AddAsync(backgroundImage);

            // Değişiklikleri kaydet
            await unitOfWork.SaveAsync(cancellationToken);

            // Boş dönmemizi sağlıyoruz; pipeline'ın doğru çalışması için
            return Unit.Value;
        }
    }
}
