using Microsoft.Extensions.DependencyInjection;
using Tasker.Shared.Extensions;
using Tasker.TruckManager.Application.Interfaces.Repositories;
using Tasker.TruckManager.Application.Interfaces.Services;

namespace Tasker.TruckManager.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddAllAsignableServices<IRepository>();
            services.AddAllAsignableServices<IService>();
            return services;
        }
    }
}
