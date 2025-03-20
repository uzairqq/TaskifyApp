using TaskifyAPI.Dtos;

namespace TaskifyAPI.Services.Interface
{
    public interface ITodoServices
    {
        Task<List<TodoDto>> GetAllTodos();
        Task<TodoDto> GetTodoById(int id);
        Task AddTodo(TodoDto taskDto);
        Task UpdateTodo(int id, TodoDto taskDto);
        Task DeleteTodo(int id);
    }
}
