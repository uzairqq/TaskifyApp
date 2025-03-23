using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskifyAPI.Models;
using TaskifyAPI.Repositories.Interface;

namespace TaskifyAPI.Repositories.Implementation
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TaskifyDbContext _context;
        private readonly ILogger<TodoRepository> _logger;

        public TodoRepository(TaskifyDbContext context, ILogger<TodoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Todo>> GetAllTodos()
        {
            _logger.LogInformation("Fetching all todos from the database.");
            var todos = await _context.Todos.ToListAsync();

            if (todos == null || !todos.Any())
            {
                _logger.LogWarning("No todos found in the database.");
            }
            else
            {
                _logger.LogInformation("{Count} todos retrieved successfully.", todos.Count);
            }

            return todos;
        }

        public async Task<Todo?> GetTodoById(int id)
        {
            _logger.LogInformation("Fetching todo with ID: {TodoId}", id);
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null)
            {
                _logger.LogWarning("Todo with ID {TodoId} not found.", id);
            }
            else
            {
                _logger.LogInformation("Todo with ID {TodoId} retrieved successfully.", id);
            }

            return todo;
        }

        public async Task AddTodo(Todo todo)
        {
            _logger.LogInformation("Adding new todo: {Title}", todo.Title);
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Todo added successfully with ID: {TodoId}", todo.Id);
        }

        public async Task UpdateTodo(Todo todo)
        {
            _logger.LogInformation("Updating todo with ID: {TodoId}", todo.Id);
            var todoResult = await _context.Todos.FindAsync(todo.Id);

            if (todoResult == null)
            {
                _logger.LogWarning("Todo with ID {TodoId} not found. Update aborted.", todo.Id);
                return;
            }

            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Todo with ID {TodoId} updated successfully.", todo.Id);
        }

        public async Task DeleteTodo(int id)
        {
            _logger.LogInformation("Deleting todo with ID: {TodoId}", id);
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Todo with ID {TodoId} deleted successfully.", id);
            }
            else
            {
                _logger.LogWarning("Todo with ID {TodoId} not found. Deletion aborted.", id);
            }
        }
    }
}
