using Tasker.TaskManager.Application.Abstractions.Repositories.TaskRepositories;
using Tasker.TaskManager.Domain.Entities;

namespace Tasker.TaskManager.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        public Task AddAsync(TaskModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TaskModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TaskModel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TaskModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

