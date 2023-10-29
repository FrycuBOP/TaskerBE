using Microsoft.Extensions.DependencyInjection;

namespace Tasker.TaskManager.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
