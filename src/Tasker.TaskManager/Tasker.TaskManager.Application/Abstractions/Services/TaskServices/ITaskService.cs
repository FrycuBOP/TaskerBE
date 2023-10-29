using Tasker.TaskManager.Application.Abstractions.Repositories;
using Tasker.TaskManager.Domain.Entities;

namespace Tasker.TaskManager.Application.Abstractions.Services.TaskServices
{
    public interface ITaskService : IBaseInterface<TaskModel>, IService
    {
    }
}
