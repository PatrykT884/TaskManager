using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Models;

namespace TaskManager.Core.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<TaskItem?> GetTaskByIdAsync(Guid id);
        Task AddTaskAsync(TaskItem Task);
        Task UpdateTaskAsync(TaskItem Task);
        Task CompleteTaskAsync(Guid id);
        Task DeleteTaskAsync(Guid id);
    }
}
