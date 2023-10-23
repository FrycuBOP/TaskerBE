using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Tasker.TaskManager.Application.Abstractions.Services.TaskServices;
using Tasker.TaskManager.Domain.Entities;

namespace Tasker.TaskManager.API.Endpoints
{
    internal static class Endpoints
    {
        internal static IApplicationBuilder MapEndpoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            endpoints.MapGroup("task-manager")
                .MapTaskManagerApi().WithTags("Task Manager").WithOpenApi());

            return app;
        }


        private static RouteGroupBuilder MapTaskManagerApi(this RouteGroupBuilder builder)
        {
            builder.MapGet("tasks", () =>
            {
                return "List Of Tasks";
            });
            builder.MapGet("task", async ([FromServices] ITaskService taskService, string taskId) =>
            {
                await taskService.GetAllAsync();
                return $"Task {taskId}";
            });
            builder.MapDelete("task", (string taskId) =>
            {
                return $"Task {taskId} deleted";
            });
            builder.MapPost("task", async ([FromServices] ITaskService taskService, [FromBody] TaskModel task) =>
            {
                await taskService.AddAsync(task);
                return "Create Task";
            });
            builder.MapPut("task", ([FromServices] ITaskService taskService, [FromBody] TaskModel task) =>
            {
                return "updated Task";
            });

            return builder;
        }
    }
}
