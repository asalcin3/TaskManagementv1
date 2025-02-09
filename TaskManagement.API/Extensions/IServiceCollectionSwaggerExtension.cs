using Microsoft.OpenApi.Models;

namespace TaskManagement.API.Extensions
{
    public static class IServiceCollectionSwaggerExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection  serviceCollection) {
            //serviceCollection.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Title = "Clean Architecture API",
            //        Version = "v1"
            //    });
            //});
            return serviceCollection;
        }
    }
}
