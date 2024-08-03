using DreamDriven.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DreamDriven.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Visual> Visuals { get; set; }
        public DbSet<WeeklyMonthlyPlan> WeeklyMonthlyPlans { get; set; }
        public DbSet<WorkSession> WorkSessions { get; set; }
        public DbSet<CategoryVisual> CategoryVisuals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
