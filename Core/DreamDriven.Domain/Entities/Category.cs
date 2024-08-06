using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {

        }

        public Category(string name, DateTime updated_at, bool isDeleted)
        {
            Name = name;
            Updated_at = updated_at;
            IsDeleted = isDeleted;

        }

        public string Name { get; set; }
        public DateTime Updated_at { get; set; }
        public bool IsDeleted { get; set; } = false;


        //BackgroundImages
        public ICollection<BackgroundImage> BackgroundImages { get; set; }
    }
}
