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

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
        }
    }
}
