using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tasker.TaskManager.Application.Abstractions.Repositories;
using Tasker.TaskManager.Application.Abstractions.Services;

namespace Tasker.TaskManager.Infrastructure
{
    public static class Extensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddAllAsignableServices<IRepository>();
            services.AddAllAsignableServices<IService>();

            return services;
        }



        private static IServiceCollection AddAllAsignableServices<T>(this IServiceCollection services) where T : class
        {
            var list = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterface(typeof(T).Name) != null && !t.IsInterface).ToList();

            foreach (var service in list)
            {
                services.AddTransient(service.GetInterface($"I{service.Name}")!, service);
            }

            return services;
        }
    }
}
