using Tasker.TaskManager.API;
using Tasker.TruckManager.API;
using Tasker.Shared;

namespace Tasker.Host.Extensions
{
    internal static class ModuleRegistrationExtension
    {
        internal static IServiceCollection AddModules(this IServiceCollection services)
        {
            services.AddTaskManager();
            services.AddTruckManager();
            return services;
        }

        internal static WebApplication UseModlues(this WebApplication app)
        {
            app.UseShared();
            app.UseTaskManager();
            app.UseTruckManager();
            return app;
        }
    }
}
