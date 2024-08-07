using DreamDriven.Domain.Entities;
using DreamDriven.Persistance.Converters;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DreamDriven.Persistance.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<BackgroundImage> BackgroundImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Counter> Counters { get; set; }
        public DbSet<Notification> Notificatins { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<UserUpload> UserUploads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tüm DateTime alanlarını UTC olarak ayarla
            foreach ( var entityType in modelBuilder.Model.GetEntityTypes() )
            {
                foreach ( var property in entityType.GetProperties() )
                {
                    if ( property.ClrType == typeof(DateTime) )
                    {
                        property.SetValueConverter(new DateTimeToUtcConverter());
                    }
                }
            }


            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
