using Microsoft.AspNetCore.Identity;
using TaskManagement.Application.Services;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Repositories.AssigneeRepository;
using TaskManagement.Infrastructure.Repositories.EmailTemplateRepository;
using TaskManagement.Infrastructure.Repositories.MessageRepository;
using TaskManagement.Infrastructure.Repositories.TaskRepository;
using TaskManagement.Infrastructure.Repositories.UserRepository;


namespace TaskManagement.API.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ITaskService, TaskService>()
                .AddScoped<ITaskRepository, TaskRepository>()
                .AddScoped<IMessagesService, MessagesService>()
                .AddScoped<IMessageRepository, MessageRepository>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ITaskAssigneesRepository, TaskAssigneesRepository>()
                .AddScoped<IEmailTemplateRepository, EmailTemplateRepository>()
                .AddScoped<IUserRepository, UserRepository>();
        }
    }
}
