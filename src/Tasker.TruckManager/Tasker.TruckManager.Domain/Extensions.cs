using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tasker.TruckManager.Domain.Persistance;

namespace Tasker.TruckManager.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddDbContext<TruckDbContext>(opt =>
            {
                opt.UseInMemoryDatabase("TruckDb");
            });
            return services;
        }

    }
}
