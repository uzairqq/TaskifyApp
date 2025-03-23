using Microsoft.Extensions.Logging;
using TaskifyAPI.Dtos;
using TaskifyAPI.Models;
using TaskifyAPI.Repositories.Interface;
using TaskifyAPI.Services.Interface;

namespace TaskifyAPI.Services.Implementation
{
    public class TodoService : ITodoServices
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger<TodoService> _logger;

        public TodoService(ITodoRepository todoRepository, ILogger<TodoService> logger)
        {
            _todoRepository = todoRepository;
            _logger = logger;
        }

        public async Task<List<TodoDto>> GetAllTodos()
        {
            _logger.LogInformation("Fetching all todos from the repository.");
            var tasks = await _todoRepository.GetAllTodos();

            if (tasks == null || !tasks.Any())
            {
                _logger.LogWarning("No todos found in the database.");
                return new List<TodoDto>();
            }

            _logger.LogInformation("{Count} todos fetched successfully.", tasks.Count);
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
            _logger.LogInformation("Fetching todo with ID: {TodoId}", id);
            var task = await _todoRepository.GetTodoById(id);

            if (task == null)
            {
                _logger.LogWarning("Todo with ID {TodoId} not found.", id);
                return null;
            }

            _logger.LogInformation("Todo with ID {TodoId} fetched successfully.", id);
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
            _logger.LogInformation("Adding a new todo: {Title}", todoDto.Title);
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
            _logger.LogInformation("Todo added successfully with ID: {TodoId}", task.Id);
        }

        public async Task UpdateTodo(int id, TodoDto todoDto)
        {
            _logger.LogInformation("Updating todo with ID: {TodoId}", id);
            var todo = await _todoRepository.GetTodoById(id);

            if (todo == null)
            {
                _logger.LogWarning("Todo with ID {TodoId} not found. Update operation aborted.", id);
                return;
            }

            todo.Title = todoDto.Title;
            todo.Description = todoDto.Description;
            todo.DueDate = todoDto.DueDate;
            todo.IsCompleted = todoDto.IsCompleted;
            todo.Status = todoDto.Status;
            todo.IsUpdated = true;

            await _todoRepository.UpdateTodo(todo);
            _logger.LogInformation("Todo with ID {TodoId} updated successfully.", id);
        }

        public async Task DeleteTodo(int id)
        {
            _logger.LogInformation("Deleting todo with ID: {TodoId}", id);
            await _todoRepository.DeleteTodo(id);
            _logger.LogInformation("Todo with ID {TodoId} deleted successfully.", id);
        }
    }
}
