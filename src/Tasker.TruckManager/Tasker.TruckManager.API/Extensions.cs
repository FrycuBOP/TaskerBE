using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Tasker.TruckManager.API.Endpoints;
using Tasker.TruckManager.Application;
using Tasker.TruckManager.Domain;
using Tasker.TruckManager.Domain.Entities;
using Tasker.TruckManager.Infrastructure;

namespace Tasker.TruckManager.API
{
    public static class Extensions
    {
        public static IServiceCollection AddTruckManager(this IServiceCollection services)
        {
            services.AddDomain();
            services.AddInfrastructure();
            services.AddApplication();
            services.AddControllers().AddOData(
                opt => opt.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null)
                .AddRouteComponents("truck-manager/odata", GetEdmModel()));
            return services;
        }

        public static IApplicationBuilder UseTruckManager(this IApplicationBuilder app)
        {
            app.MapEndpoints();
            return app;
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Truck>("Trucks");

            return builder.GetEdmModel();
        }
    }
}
