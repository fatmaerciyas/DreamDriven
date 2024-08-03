using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class CategoryVisual : IEntityBase
    {
        public int CategoryId { get; set; }
        public int VisualId { get; set; }
        public Category Category { get; set; }
        public Visual Visual { get; set; }
    }
}
