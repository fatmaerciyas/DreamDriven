using DreamDriven.Application.Interfaces.UnitOfWorks;
using MediatR;

namespace DreamDriven.Application.Features.UserUpload.Command.CreateUserUpload
{
    public class CreateUserUploadCommandHandler : IRequestHandler<CreateUserUploadCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateUserUploadCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateUserUploadCommandRequest request, CancellationToken cancellationToken)
        {
            Guid UserId = Guid.NewGuid();

            // Yeni Todo nesnesi oluşturma
            var userUpload = new Domain.Entities.UserUpload(
                fileUrl: request.FileUrl,
                category_Id: request.CategoryId,
                userId: UserId, // Kullanıcının ID'si
                isDeleted: false // Varsayılan olarak false
            );

            // Todo nesnesini ekleme
            await unitOfWork.GetWriteRepository<Domain.Entities.UserUpload>().AddAsync(userUpload);

            // Değişiklikleri kaydet
            await unitOfWork.SaveAsync(cancellationToken);

            // Boş dönmemizi sağlıyoruz; pipeline'ın doğru çalışması için
            return Unit.Value;
        }
    }
}
