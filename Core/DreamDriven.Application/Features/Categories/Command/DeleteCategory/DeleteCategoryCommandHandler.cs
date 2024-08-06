using DreamDriven.Application.Features.Categories.Command.DeleteFolder;
using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        // Constructor: IUnitOfWork nesnesini alır ve sınıfın private alanına atar
        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            // Belirtilen ID'ye sahip ve silinmemiş kategoriyi al
            var category = await unitOfWork.GetReadRepository<Category>().GetAsync(
                x => x.Id == request.Id && !x.IsDeleted
            );

            // Kategori mevcut değilse, bir hata fırlatabiliriz ya da uygun bir işlem yapabiliriz
            if ( category == null )
            {
                // Bu kısımda kategori bulunamazsa yapılacak işlemi belirlemelisiniz.
                // Örneğin, bir istisna fırlatabilirsiniz veya bir hata mesajı dönebilirsiniz.
                throw new KeyNotFoundException("There is no such a category");
            }

            // Kategoriyi silinmiş olarak işaretle
            category.IsDeleted = true;

            // Kategoriyi güncelle
            await unitOfWork.GetWriteRepository<Category>().UpdateAsync(category);

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.SaveAsync(cancellationToken = default);

            // İşlem tamamlandığında boş döner; MediatR kullanımı için
            return Unit.Value;
        }
    }
}
