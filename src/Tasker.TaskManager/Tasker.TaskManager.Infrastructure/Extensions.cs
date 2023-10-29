using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tasker.TaskManager.Application.Abstractions.Repositories;
using Tasker.TaskManager.Application.Abstractions.Services;
using Tasker.Shared.Extensions;

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
    }
}
