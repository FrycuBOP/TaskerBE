using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Tasker.Shared.Middlewares;

namespace Tasker.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddScoped<ExceptionMiddleware>();
            return services;
        }

        public static IApplicationBuilder UseShared(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            return app;
        }
    }
}
