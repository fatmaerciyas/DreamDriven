using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class Counter : EntityBase
    {
        public Counter()
        {
        }

        public Counter(string name, string description, DateTime updated_at, Guid userId)
        {
            Name = name;
            Description = description;
            Updated_at = updated_at;
            UserId = userId;

        }


        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Updated_at { get; set; }

        //User
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
