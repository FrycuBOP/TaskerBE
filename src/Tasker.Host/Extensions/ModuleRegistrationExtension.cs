using Tasker.TaskManager.API;
using Tasker.TruckManager.API;
using Tasker.Shared;
using Tasker.Shared.Settings;

namespace Tasker.Host.Extensions
{
    internal static class ModuleRegistrationExtension
    {
        internal static IServiceCollection AddModules(this IServiceCollection services, ModulesSettings modulesSettings)
        {

            services.AddShared();

            if (modulesSettings.TaskManager)
                services.AddTaskManager();
            if (modulesSettings.TruckManager)
                services.AddTruckManager();

            return services;
        }

        internal static WebApplication UseModlues(this WebApplication app, ModulesSettings modulesSettings)
        {
            app.UseShared();
            if (modulesSettings.TaskManager)
                app.UseTaskManager();
            if (modulesSettings.TruckManager)
                app.UseTruckManager();
            return app;
        }
    }
}
