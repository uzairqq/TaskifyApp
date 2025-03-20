using Microsoft.EntityFrameworkCore;
using TaskifyAPI.Dtos;
using TaskifyAPI.Models;
using TaskifyAPI.Repositories.Interface;

namespace TaskifyAPI.Repositories.Implementation
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TaskifyDbContext _context;

        public TodoRepository(TaskifyDbContext context)
        {
            _context = context;
        }
        public async Task<List<Todo>> GetAllTodos()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo?> GetTodoById(int id)
        {
           return await _context.Todos.FindAsync(id);
        }

        public async Task AddTodo(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodo(Todo todo)
        {
            var todoResult = await _context.Todos.FindAsync(todo.Id);

            if (todoResult == null)
                return;

            _context.Todos.Update(todoResult);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodo(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }
       
    }
}
