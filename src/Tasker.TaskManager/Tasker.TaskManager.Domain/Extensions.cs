using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Tasker.TaskManager.Domain.Entities.Validators;

namespace Tasker.TaskManager.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<TaskValidator>();

            return services;
        }
    }
}
