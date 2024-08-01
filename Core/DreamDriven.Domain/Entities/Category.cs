using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }

        //Many to many
        public ICollection<Visual> Visuals { get; set; }
    }
}
