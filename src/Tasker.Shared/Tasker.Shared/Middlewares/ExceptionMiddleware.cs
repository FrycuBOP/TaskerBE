using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Tasker.Shared.Exceptions;

namespace Tasker.Shared.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (TaskerBaseException ex)
            {
                var errorCode = ToUnderscoreCase(ex.GetType().Name.Replace("Exception", String.Empty));
                _logger.LogError(ex, $"{ex.ExceptionMessage} | Error code = {ex.StatusCode}", ex.Message, errorCode);
                context.Response.StatusCode = ex.StatusCode;
                context.Response.ContentType = "application/json";

                var json = JsonSerializer.Serialize(new { ErrorCode = errorCode,ex.ExceptionMessage });
                await context.Response.WriteAsync(json);
            }
            catch (Exception ex)
            {
                var errorCode = ToUnderscoreCase(ex.GetType().Name.Replace("Exception", string.Empty));
                _logger.LogError(ex,
                    "Error when executing service method | Error code {ErrorCode} | {Message}", errorCode, ex.Message);

                context.Response.StatusCode = 500;
                var json = JsonSerializer.Serialize(new { ErrorCode = "Internal server error", Message = "Internal server error" });
                await context.Response.WriteAsync(json);
            }
        }

        private static string ToUnderscoreCase(string value)
            => string.Concat((value ?? string.Empty).Select((x, i) => i > 0 && char.IsUpper(x) && !char.IsUpper(value[i - 1]) ? $"_{x}" : x.ToString())).ToLower();
    }
}
