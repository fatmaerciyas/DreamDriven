using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        // Constructor: IUnitOfWork nesnesini alır ve sınıfın private alanına atar
        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
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

            // Kategori üzerinde güncelleme yap
            // Güncellenmiş ad ve tarihleri kullanarak kategori nesnesini güncelle
            category.Name = request.Name;
            category.Updated_at = DateTime.Now;

            // Kategoriyi güncelle
            await unitOfWork.GetWriteRepository<Category>().UpdateAsync(category);

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.SaveAsync(cancellationToken = default);

            // İşlem tamamlandığında boş döner; MediatR kullanımı için
            return Unit.Value;
        }
    }
}
