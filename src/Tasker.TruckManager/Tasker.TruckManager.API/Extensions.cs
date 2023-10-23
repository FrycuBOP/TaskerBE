using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Tasker.TruckManager.API.Endpoints;
using Tasker.TruckManager.Application;
using Tasker.TruckManager.Domain;
using Tasker.TruckManager.Infrastructure;

namespace Tasker.TruckManager.API
{
    public static class Extensions
    {
        public static IServiceCollection AddTruckManager(this IServiceCollection services)
        {
            services.AddDomain();
            services.AddApplication();
            services.AddInfrastructure();
            return services;
        }

        public static IApplicationBuilder UseTruckManager(this IApplicationBuilder app)
        {
            app.MapEndpoints();
            return app;
        }
    }
}
