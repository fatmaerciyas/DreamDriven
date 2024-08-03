using DreamDriven.Domain.Common;

namespace DreamDriven.Domain.Entities
{
    public class Visual : EntityBase
    {
        public string FilePath { get; set; } // Görsel dosyasının yolu veya URL'si
        public string Description { get; set; } // Görsel açıklaması

        // Categories
        public ICollection<CategoryVisual> CategoryVisuals { get; set; }

        // User
        public Guid? UserId { get; set; } // Nullable in case some visuals are not user-specific
        public User User { get; set; } // Navigation property to User
    }

}
