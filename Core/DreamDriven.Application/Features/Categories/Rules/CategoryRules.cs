using DreamDriven.Application.Bases;
using DreamDriven.Application.Features.Categories.Exceptions;
using DreamDriven.Domain.Entities;

namespace DreamDriven.Application.Features.Categories.Rules
{
    public class CategoryRules : BaseRules
    {
        public Task CategoryNameMustNotBeSame(IList<Category> categories, string requestName)
        {
            if ( categories.Any(x => x.Name == requestName) ) throw new CategoryNameMustNotBeSame();

            return Task.CompletedTask;
        }
    }
}
