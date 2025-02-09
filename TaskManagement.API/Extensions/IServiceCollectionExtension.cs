using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Services;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Repositories.TaskRepository;


namespace TaskManagement.API.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ITaskService, TaskService>()
                .AddScoped<ITaskRepository, TaskRepository>();

        }
    }
}
