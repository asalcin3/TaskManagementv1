using brevo_csharp.Client;
using TaskManagement.Application.Services;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Brevo;
using TaskManagement.Infrastructure.Repositories.TaskRepository;

namespace TaskManagement.API.Extensions
{
    public static class IServiceCollectionBrevoExtension
    {
        public static IServiceCollection AddBrevoService(this IServiceCollection services, IConfiguration configuration)
        {
            var brevoApiKey = configuration["Brevo:ApiKey"];
            var brevoConfig = new Configuration();
            brevoConfig.ApiKey.Add("api-key", brevoApiKey);

            services.AddSingleton(brevoConfig); // One instance of a resource, reused anytime it's requested.
            services.AddTransient<IBrevoEmailService, BrevoEmailService>(); //A different instance of a resource, everytime it's requested.

            return services;

        }
    }
}
