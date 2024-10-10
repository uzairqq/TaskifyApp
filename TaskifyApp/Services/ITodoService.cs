using TaskifyApp.Dto;

namespace TaskifyApp.Services
{
    public interface ITodoService
    {
        Task<List<TodoDto>> GetAllAsync();
        Task<TodoDto> GetByIdAsync(int id);
        Task AddAsync(TodoDto todoDto);
        Task UpdateAsync(TodoDto todoDto);
        Task DeleteAsync(int id);
    }
}
