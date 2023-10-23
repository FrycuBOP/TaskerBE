using Microsoft.Extensions.DependencyInjection;

namespace Tasker.TruckManager.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services;
        }
    }
}
