using DreamDriven.Application.Features.Categories.Rules;
using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CategoryRules categoryRules;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, CategoryRules categoryRules)
        {
            this.unitOfWork = unitOfWork;
            this.categoryRules = categoryRules;
        }

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            // Tüm kategorileri al
            IList<Category> categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync();

            // Kategori adının benzersiz olması gerektiğini doğrula
            await categoryRules.CategoryNameMustNotBeSame(categories, request.Name);

            // Yeni kategori oluştur
            Category category = new Category(request.Name, request.Updated_At, false);

            // Yeni kategoriyi ekle
            await unitOfWork.GetWriteRepository<Category>().AddAsync(category);

            // Değişiklikleri kaydet
            await unitOfWork.SaveAsync(cancellationToken);

            // Bos dönmemizi saglıyoruz; pipeline'ın doğru çalışması için
            return Unit.Value;
        }
    }
}
