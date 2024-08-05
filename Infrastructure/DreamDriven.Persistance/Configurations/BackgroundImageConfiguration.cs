using DreamDriven.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DreamDriven.Persistance.Configurations
{
    internal class BackgroundImageConfiguration : IEntityTypeConfiguration<BackgroundImage>
    {
        public void Configure(EntityTypeBuilder<BackgroundImage> builder)
        {
            builder.Property
        }
    }
}
