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

            IList<Category> categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync();

            //if ( categories.Any(x => x.Name == request.Name) )
            //    throw new Exception("The category with this name already exists ");

            await categoryRules.CategoryNameMustNotBeSame(categories, request.Name);

            foreach ( var item in categories )
            {
                if ( item.Name == request.Name ) { }
            }

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

            //Bos donmemizi sagliyor pipelinein dogru calismasi icin
            return Unit.Value;
        }
    }
}
