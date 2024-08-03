using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = new Category(request.Name);

            await unitOfWork.GetWriteRepository<Category>().AddAsync(category);

            if ( await unitOfWork.SaveAsync() > 0 )
            {
                //await unitOfWork.GetWriteRepository<CategoryVisual>().AddAsync(new()
                //{

                //    // ?
                //});

                await unitOfWork.SaveAsync();
            }
        }
    }
}
