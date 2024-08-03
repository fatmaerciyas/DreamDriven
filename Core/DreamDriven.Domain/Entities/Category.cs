using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {

        }

        public Category(string Name)
        {
            this.Name = Name;
        }

        public string Name { get; set; }

        //Many to many
        public ICollection<CategoryVisual> CategoryVisuals { get; set; }
    }
}
