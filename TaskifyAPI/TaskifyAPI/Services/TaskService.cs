using TaskifyAPI.Dto;
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
        public async Task<TaskReadDto> AddAsync(TaskUpsertDto dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = dto.IsCompleted
            };

            var created = await _taskRepository.AddAsync(task);

            return new TaskReadDto
            {
                Id = created.Id,
                Title = created.Title,
                IsCompleted = created.IsCompleted
            };
        }
        public Task<bool> DeleteAsync(int id) => _taskRepository.DeleteAsync(id);
        public async Task<IEnumerable<TaskReadDto>> GetAllAsync()
        {
            var tasks = await _taskRepository.GetAllAsync();
            return tasks.Select(t => new TaskReadDto
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted
            });

        }
        public async Task<TaskReadDto?> GetByIdAsync(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null)
                return null;

            return new TaskReadDto
            {
                Id = task.Id,
                Title = task.Title,
                IsCompleted = task.IsCompleted
            };
        }
        public async Task<TaskReadDto?> UpdateAsync(int id, TaskUpsertDto dto)
        {
            var existing = await _taskRepository.GetByIdAsync(id);
            if (existing == null)
                return null;

            existing.Title = dto.Title;
            existing.Description = dto.Description;
            existing.IsCompleted = dto.IsCompleted;

            var updated = await _taskRepository.UpdateAsync(existing);

            return new TaskReadDto
            {
                Id = updated.Id,
                Title = updated.Title,
                IsCompleted = updated.IsCompleted
            };
        }
    }
}
