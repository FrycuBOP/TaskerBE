using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Tasker.TaskManager.API.Endpoints;
using Tasker.TaskManager.Application;
using Tasker.TaskManager.Domain;
using Tasker.TaskManager.Infrastructure;

namespace Tasker.TaskManager.API
{
    public static class Extensions
    {
        public static IServiceCollection AddTaskManager(this IServiceCollection services)
        {
            services.AddDomain();
            services.AddApplication();
            services.AddInfrastructure();
            return services;
        }

        public static IApplicationBuilder UseTaskManager(this IApplicationBuilder app)
        {
            app.MapEndpoints();
            return app;
        }
    }
}
