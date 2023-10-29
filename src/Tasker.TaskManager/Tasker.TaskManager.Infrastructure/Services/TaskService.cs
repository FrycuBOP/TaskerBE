using FluentValidation;
using Tasker.TaskManager.Application.Abstractions.Repositories.TaskRepositories;
using Tasker.TaskManager.Application.Abstractions.Services.TaskServices;
using Tasker.TaskManager.Domain.Entities;

namespace Tasker.TaskManager.Infrastructure.Services
{
    internal class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IValidator<TaskModel> _validator;

        public TaskService(ITaskRepository taskRepository, IValidator<TaskModel> validator)
        {
            _taskRepository = taskRepository;
            _validator = validator;
        }

        public async Task AddAsync(TaskModel entity)
        {
            if (_validator.Validate(entity).IsValid)
            {
                await _taskRepository.AddAsync(entity);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _taskRepository.DeleteAsync(id);
        }

        public async Task<IReadOnlyList<TaskModel>> GetAllAsync()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task<TaskModel> GetByIdAsync(Guid id)
        {
            return await _taskRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(TaskModel entity)
        {
            if (_validator.Validate(entity).IsValid)
            {
                await _taskRepository.UpdateAsync(entity);
            }
        }
    }
}
