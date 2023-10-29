using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.OData.Query;
using Tasker.TruckManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Tasker.TruckManager.Infrastructure.Interfaces.Services;

namespace Tasker.TruckManager.API.Endpoints
{
    internal static class Endpoints
    {
        internal static IApplicationBuilder MapEndpoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGroup("truck-manager")
                    .MapTaskManagerApi().WithTags("Truck Manager").WithOpenApi();
            });
            return app;
        }
        private static RouteGroupBuilder MapTaskManagerApi(this RouteGroupBuilder builder)
        {
            builder.MapGet("truck", async ([FromServices]ITruckService _truckService,[FromQuery] string id, CancellationToken cancellationToken) =>
            {
                return await _truckService.GetById(Guid.Parse(id), cancellationToken);
            });

            builder.MapPost("truck", async ([FromServices] ITruckService _truckService, [FromBody] Truck truck, CancellationToken cancellationToken) =>
            {
                return await _truckService.AddTruck(truck, cancellationToken);
            });

            builder.MapPut("truck", async ([FromServices] ITruckService _truckService, [FromBody] Truck truck, CancellationToken cancellationToken) =>
            {
                await _truckService.Update(truck, cancellationToken);

                return Results.Ok();
            });

            builder.MapDelete("truck", async ([FromServices] ITruckService _truckService, [FromBody] string id, CancellationToken cancellationToken) =>
            {
                await _truckService.Delete(Guid.Parse(id), cancellationToken);

                return Results.Ok();
            });

            return builder;
        }
    }
}
