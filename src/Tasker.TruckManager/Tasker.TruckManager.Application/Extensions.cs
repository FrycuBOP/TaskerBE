using Microsoft.Extensions.DependencyInjection;
using Tasker.Shared.Extensions;
using Tasker.TruckManager.Infrastructure.Interfaces.Repositories;
using Tasker.TruckManager.Infrastructure.Interfaces.Services;

namespace Tasker.TruckManager.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAllAsignableServices<IRepository>();
            services.AddAllAsignableServices<IService>();
            return services;
        }
    }
}
