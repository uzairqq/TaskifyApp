using TaskifyApp.Models;

namespace TaskifyApp.Repository
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetAllAsync();
        Task<TodoItem> GetByIdAsync(long id);
        Task AddAsync(TodoItem todo);
        Task UpdateAsync(TodoItem todo);
        Task DeleteAsync(int id);
        Task<IEnumerable<TodoItem>> GetTodosAsync(PaginationFilter filter);
        Task<int> GetTodoCountAsync();
    }
}
