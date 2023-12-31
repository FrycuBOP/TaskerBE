﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Tasker.Shared.Exceptions.CommonExceptions;
using Tasker.TruckManager.Application.Interfaces.Services;
using Tasker.TruckManager.Domain.Entities;

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
            builder.MapGet("truck", async ([FromServices] ITruckService _truckService, [FromQuery] string id, CancellationToken cancellationToken) =>
            {
                var guidId = new Guid();
                if (!Guid.TryParse(id, out guidId))
                {
                    throw new BadRequestException("id value is incorrect");
                }
                return await _truckService.GetById(guidId, cancellationToken);
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
