using TaskifyAPI.Dtos;
using TaskifyAPI.Models;

namespace TaskifyAPI.Repositories.Interface
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllTodos();
        Task<Todo> GetTodoById(int id);
        Task AddTodo(Todo todo);
        Task UpdateTodo(Todo todo);
        Task DeleteTodo(int id);
    }
}
