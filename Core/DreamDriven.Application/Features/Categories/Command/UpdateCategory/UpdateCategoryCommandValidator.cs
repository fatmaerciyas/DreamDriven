using FluentValidation;

namespace DreamDriven.Application.Features.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryCommandValidator()
        {

            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithName("Category Id");


            RuleFor(x => x.Name)
               .NotEmpty()
               .WithName("Category Name");



        }
    }
}
