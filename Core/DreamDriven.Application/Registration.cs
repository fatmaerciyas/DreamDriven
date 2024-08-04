using DreamDriven.Application.Bases;
using DreamDriven.Application.Behaviors;
using DreamDriven.Application.Exceptions;
using FluentValidation;
using MediatR;
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

            services.AddTransient<ExceptionMiddleware>(); // Exception Middleware

            //services.AddTransient<CategoryRules>(); // Ayni isme sahip kategorilerin olmamasi icin bir kural yazdım onu tanimladim

            services.AddRulesFromAssemblyContainig(assembly, typeof(BaseRules));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly)); // Mediatr

            services.AddValidatorsFromAssembly(assembly);  //Fluent Validation
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));// MediatR ve FluentValidation'ı birlikte kullanırken gerekli olan bir yapılandırma

            //ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");   Mesajlarin turkce olmasi icin


        }

        private static IServiceCollection AddRulesFromAssemblyContainig(this IServiceCollection services, Assembly assembly, Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach ( var t in types )
                services.AddTransient(t);
            return services;
        }
    }
}
