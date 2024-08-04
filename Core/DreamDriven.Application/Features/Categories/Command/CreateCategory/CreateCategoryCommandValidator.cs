using FluentValidation;

namespace DreamDriven.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithName("Category Name");


            //RuleFor(x => x.Id)
            //    .GreaterThan(0)
            //    .WithName("Category Name");
        }
    }
}
