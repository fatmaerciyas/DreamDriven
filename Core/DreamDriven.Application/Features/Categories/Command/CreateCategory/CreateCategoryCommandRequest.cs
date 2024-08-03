using MediatR;

namespace DreamDriven.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest
    {
        //Category olusturulurken ihtiyacim olan alanlar
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
