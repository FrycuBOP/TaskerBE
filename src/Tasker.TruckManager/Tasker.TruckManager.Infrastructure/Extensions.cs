using Microsoft.Extensions.DependencyInjection;
using Tasker.TruckManager.Infrastructure.Interfaces.Repositories;
using Tasker.TruckManager.Infrastructure.Interfaces.Services;
using Tasker.Shared.Extensions;

namespace Tasker.TruckManager.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            return services;
        }
    }
}
