using Taskify_API.Dto;
using Taskify_API.Models;
using Task = Taskify_API.Models.Task;

namespace Taskify_API.Repository
{
    public interface ITaskRepository
    {
        Task<Task> PostAsync(Task input);
        Task<Task> DeleteAsync(Task task);
        Task<List<Task>> GetListAsync();
        Task<Task> GetByIdAsync(int id);
        Task<Task> PutAsync(Task input);
    }
}
