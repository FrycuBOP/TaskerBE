using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.Shared.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddAllAsignableServices<T>(this IServiceCollection services) where T : class
        {
            var list = Assembly.GetCallingAssembly().GetTypes().Where(t => t.GetInterface(typeof(T).Name) != null && !t.IsInterface).ToList();

            foreach (var service in list)
            {
                services.AddTransient(service.GetInterface($"I{service.Name}")!, service);
            }

            return services;
        }
    }
}
