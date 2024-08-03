using DreamDriven.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DreamDriven.Persistance.Configurations
{
    public class CategoryVisualConfiguration : IEntityTypeConfiguration<CategoryVisual>
    {
        public void Configure(EntityTypeBuilder<CategoryVisual> builder)
        {
            builder.HasKey(x => new { x.CategoryId, x.VisualId });

            builder.HasOne(c => c.Category)
                .WithMany(cv => cv.CategoryVisuals)
                .HasForeignKey(p => p.CategoryId); // .OnDelete(DeleteBehavior.Cascade) category sildiğinde o categoriyle baglantılı olan her sey silinir

            builder.HasOne(v => v.Visual)
                .WithMany(cv => cv.CategoryVisuals)
                .HasForeignKey(p => p.VisualId);
        }
    }
}
