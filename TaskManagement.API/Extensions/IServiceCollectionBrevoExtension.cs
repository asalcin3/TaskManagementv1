using brevo_csharp.Client;
using Microsoft.Extensions.Options;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Brevo;
using TaskManagement.Infrastructure.Configuration;

namespace TaskManagement.API.Extensions
{
    public static class IServiceCollectionBrevoExtension
    {
        public static IServiceCollection AddBrevoService(this IServiceCollection services, IConfiguration configuration)
        {
            // Bind Brevo settings
            services.Configure<BrevoConfig>(configuration.GetSection("BrevoConfig"));

            // Register Brevo SDK Configuration
            services.AddSingleton(provider =>
            {
                var brevoSettings = provider.GetRequiredService<IOptions<BrevoConfig>>().Value;

                var brevoConfigAPI = new Configuration();
                brevoConfigAPI.ApiKey.Add("api-key", brevoSettings.ApiKey);

                return brevoConfigAPI;
            });

            services.AddTransient<IBrevoEmailService, BrevoEmailService>(); //A different instance of a resource, everytime it's requested.

            return services;

        }
    }
}
