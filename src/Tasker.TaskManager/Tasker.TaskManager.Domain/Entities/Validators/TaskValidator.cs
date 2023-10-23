using FluentValidation;

namespace Tasker.TaskManager.Domain.Entities.Validators
{
    public class TaskValidator : AbstractValidator<TaskModel>
    {
        public TaskValidator()
        {
            RuleFor(task => task.EstimatedTime).GreaterThanOrEqualTo(0).WithMessage("Estimated time must have positive or zero value");
            RuleFor(task => task.LastModified).LessThanOrEqualTo(DateTime.UtcNow).When(x => x.LastModified.HasValue).WithMessage("Last modified date can't be past date");
            RuleFor(task => task.ModifiedReason).NotEmpty().When(x => x.LastModified.HasValue).WithMessage("Modified reason can't have empty value");
        }
    }
}
