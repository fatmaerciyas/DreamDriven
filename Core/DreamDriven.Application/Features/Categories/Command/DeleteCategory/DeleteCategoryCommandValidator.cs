using DreamDriven.Application.Features.Categories.Command.DeleteFolder;
using FluentValidation;

namespace DreamDriven.Application.Features.Categories.Command.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommandRequest>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
              .GreaterThan(0);


        }
    }
}
