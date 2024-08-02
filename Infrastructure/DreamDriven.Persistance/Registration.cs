using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Application.Repositories;
using DreamDriven.Persistance.Context;
using DreamDriven.Persistance.Repositories;
using DreamDriven.Persistance.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DreamDriven.Persistance
{
    public static class Registration
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

                services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
                services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
                services.AddScoped<IUnitOfWork, UnitOfWork>();
            });
        }
    }
}

