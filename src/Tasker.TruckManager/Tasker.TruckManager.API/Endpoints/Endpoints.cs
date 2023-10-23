
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Tasker.TruckManager.API.Endpoints
{
    internal static class Endpoints
    {
        internal static IApplicationBuilder MapEndpoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            endpoints.MapGroup("truck-manager")
                .MapTaskManagerApi().WithTags("Truck Manager").WithOpenApi());

            return app;
        }


        private static RouteGroupBuilder MapTaskManagerApi(this RouteGroupBuilder builder)
        {
            builder.MapGet("truck", () =>
            {
                return "List Of Tasks";
            });
            builder.MapGet("truck", async ([FromServices] ITaskService taskService, string taskId) =>
            {
                await taskService.GetAllAsync();
                return $"Task {taskId}";
            });
            builder.MapDelete("truck", (string taskId) =>
            {
                return $"Task {taskId} deleted";
            });
            builder.MapPost("truck", async ([FromServices] ITaskService taskService, [FromBody] TaskModel task) =>
            {
                await taskService.AddAsync(task);
                return "Create Task";
            });
            builder.MapPut("truck", ([FromServices] ITaskService taskService, [FromBody] TaskModel task) =>
            {
                return "updated Task";
            });

            return builder;
        }
    }
}
