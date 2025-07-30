using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Repositories;

namespace TaskManager.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        public async Task<TaskItem> GetTaskByIdAsync(Guid id)
        {
            return await _taskRepository.GetTaskByIdAsync(id);
        }

        public async Task AddTaskAsync(TaskItem task)
        {
            await _taskRepository.AddTaskAsync(task);
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            await _taskRepository.UpdateTaskAsync(task);
        }

        public async Task CompleteTaskAsync(Guid id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task != null)
            {
                task.IsCompleted = true;
                await _taskRepository.UpdateTaskAsync(task);
            }
        }

        public async Task DeleteTaskAsync(Guid id)
        {
                await _taskRepository.DeleteTaskAsync(id);
        }
    }
}
