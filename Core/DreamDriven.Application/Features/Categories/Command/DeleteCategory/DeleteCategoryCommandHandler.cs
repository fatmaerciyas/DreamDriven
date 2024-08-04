using DreamDriven.Application.Features.Categories.Command.DeleteFolder;
using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.GetReadRepository<Category>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            category.IsDeleted = true;

            await unitOfWork.GetWriteRepository<Category>().UpdateAsync(category);

            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
