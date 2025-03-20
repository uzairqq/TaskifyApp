using TaskifyAPI.Dtos;
using TaskifyAPI.Models;
using TaskifyAPI.Repositories.Interface;
using TaskifyAPI.Services.Interface;

namespace TaskifyAPI.Services.Implementation
{
    public class TodoService : ITodoServices
    {
        private readonly ITodoRepository _todoRepository;
        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<List<TodoDto>> GetAllTodos()
        {
            var tasks = await _todoRepository.GetAllTodos();
            return tasks.Select(t => new TodoDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                IsCompleted = t.IsCompleted,
                Status = t.Status
            }).ToList();
        }

        public async Task<TodoDto> GetTodoById(int id)
        {
            var task = await _todoRepository.GetTodoById(id);
            if (task == null) return null;

            return new TodoDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                IsCompleted = task.IsCompleted,
                Status = task.Status
            };
        }

        public async Task AddTodo(TodoDto todoDto)
        {
            var task = new Todo
            {
                Title = todoDto.Title,
                Description = todoDto.Description,
                DueDate = todoDto.DueDate,
                IsCompleted = todoDto.IsCompleted,
                Status = todoDto.Status,
                IsUpdated = false,
                IsDeleted = false,
                UserId = 1 // Change this based on authentication
            };

            await _todoRepository.AddTodo(task);
        }

        public async Task UpdateTodo(int id, TodoDto todoDto)
        {
            var todo = await _todoRepository.GetTodoById(id);
            if (todo == null) return;

            todo.Title = todoDto.Title;
            todo.Description = todoDto.Description;
            todo.DueDate = todoDto.DueDate;
            todo.IsCompleted = todoDto.IsCompleted;
            todo.Status = todoDto.Status;
            todo.IsUpdated = true;

            await _todoRepository.UpdateTodo(todo);
        }

        public async Task DeleteTodo(int id)
        {
            await _todoRepository.DeleteTodo(id);
        }
    }
}
