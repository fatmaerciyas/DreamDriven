using DreamDriven.Application.Interfaces.AutoMapper;
using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.GetReadRepository<Category>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            var map = mapper.Map<Category, UpdateCategoryCommandRequest>(category);

            var categoryVisuals = await unitOfWork.GetReadRepository<CategoryVisual>()
                .GetAllAsync(x => x.CategoryId == category.Id);

            await unitOfWork.GetWriteRepository<CategoryVisual>().HardDeleteRangeAsync(categoryVisuals);


            await unitOfWork.GetWriteRepository<Category>().UpdateAsync(map);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
