using System.ComponentModel.DataAnnotations;

namespace DreamDriven.Domain.Common
{
    public class EntityBase : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
