using Microsoft.EntityFrameworkCore;
using TaskifyApp.Dto;
using TaskifyApp.Exceptions;
using TaskifyApp.Models;

namespace TaskifyApp.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TaskifyDbContext _context;

        public TodoRepository(TaskifyDbContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            try
            {
                return await _context.TodoItems.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error In Getting All Todos From Database", ex);
            }
        }

        public async Task<IEnumerable<TodoItem>> GetTodosAsync(PaginationFilter filter)
        {
            var query = _context.TodoItems.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(t => t.Title.Contains(filter.Title));
            }

            if (!string.IsNullOrEmpty(filter.Description))
            {
                query = query.Where(t => t.Description.Contains(filter.Description));
            }
            query = query.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize);

            return await query.ToListAsync();
        }

        public async Task<int> GetTodoCountAsync()
        {
            return await _context.TodoItems.CountAsync();
        }


        public async Task<TodoItem> GetByIdAsync(long id)
        {
            try
            {
                return await _context.TodoItems.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error In Getting Todo By Id From Database", ex);
            }
        }

        public async Task AddAsync(TodoItem todo)
        {
            try
            {
                _context.TodoItems.Add(todo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error In Adding Todo Item To Database", ex);
            }

        }

        public async Task UpdateAsync(TodoItem todo)
        {
            try
            {
                _context.TodoItems.Update(todo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error In Updating Todo Item To Database", ex);
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var todo = await _context.TodoItems.FirstOrDefaultAsync(i => i.Id == id);
                if (todo != null)
                {
                    _context.TodoItems.Remove(todo);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // Handle the case where the todo item is not found
                    throw new RepositoryException($"Todo item with id {id} not found", null);
                }
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error In Deleting Todo Item From Database", ex);
            }
        }
    }
}
