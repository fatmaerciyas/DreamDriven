using DreamDriven.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DreamDriven.Application
{

    //Features icindeki Mediatr islemlerini tanimlamak icin
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
        }
    }
}
