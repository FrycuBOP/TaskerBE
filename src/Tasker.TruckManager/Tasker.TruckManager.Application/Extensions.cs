using Microsoft.Extensions.DependencyInjection;
using Tasker.Shared.Extensions;
using Tasker.TruckManager.Application.Interfaces.Repositories;
using Tasker.TruckManager.Application.Interfaces.Services;

namespace Tasker.TruckManager.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            return services;
        }
    }
}
