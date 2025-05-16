using TaskifyAPI.Dto;
using TaskifyAPI.Models;

namespace TaskifyAPI.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskReadDto>> GetAllAsync();
        Task<TaskReadDto?> GetByIdAsync(int id);
        Task<TaskReadDto> AddAsync(TaskUpsertDto dto);
        Task<TaskReadDto?> UpdateAsync(int id,TaskUpsertDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
