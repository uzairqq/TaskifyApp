using TaskifyAPI.Models;

namespace TaskifyAPI.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(int id);
        Task<TaskItem> AddAsync(TaskItem taskItem);
        Task<TaskItem?> UpdateAsync(TaskItem taskItem);
        Task<bool> DeleteAsync(int id);
    }
}
