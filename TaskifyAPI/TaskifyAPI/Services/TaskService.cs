using TaskifyAPI.Models;
using TaskifyAPI.Repositories;

namespace TaskifyAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public Task<TaskItem> AddAsync(TaskItem taskItem) => _taskRepository.AddAsync(taskItem);

        public Task<bool> DeleteAsync(int id) => _taskRepository.DeleteAsync(id);

        public Task<IEnumerable<TaskItem>> GetAllAsync() => _taskRepository.GetAllAsync();

        public Task<TaskItem?> GetByIdAsync(int id) => _taskRepository.GetByIdAsync(id);

        public Task<TaskItem?> UpdateAsync(TaskItem taskItem) => _taskRepository.UpdateAsync(taskItem);
    }
}
