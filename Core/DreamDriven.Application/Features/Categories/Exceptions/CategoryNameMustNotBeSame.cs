using DreamDriven.Application.Bases;

namespace DreamDriven.Application.Features.Categories.Exceptions
{
    public class CategoryNameMustNotBeSame : BaseExceptions
    {
        public CategoryNameMustNotBeSame() : base("There is a category already has that name") { }

    }
}
