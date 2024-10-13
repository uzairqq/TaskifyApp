// TodoService.cs
using TaskifyApp.Dto;
using TaskifyApp.Exceptions;
using TaskifyApp.Models;
using TaskifyApp.Repository;
using TaskifyApp.Services;

namespace TaskifyApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TodoDto>> GetAllAsync()
        {
            try
            {
                var todos = await _repository.GetAllAsync();
                return todos.Select(todo => new TodoDto
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Description = todo.Description,
                    IsCompleted = todo.IsCompleted
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error In Getting All todo Items", ex);
            }
        }

        public async Task<TodoDto> GetByIdAsync(int id)
        {
            try
            {
                var todo = await _repository.GetByIdAsync(id);
                if (todo == null)
                {
                    return null;
                }

                return new TodoDto
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Description = todo.Description,
                    IsCompleted = todo.IsCompleted
                };
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error In Getting todo item By Id", ex);
            }

        }

        public async Task AddAsync(TodoDto todoDto)
        {
            try
            {
                var todo = new TodoItem
                {
                    Title = todoDto.Title,
                    Description = todoDto.Description,
                    IsCompleted = todoDto.IsCompleted
                };
                await _repository.AddAsync(todo);
                todoDto.Id = todo.Id;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error In Getting todo item By Id", ex);
                throw;
            }
        }

        public async Task UpdateAsync(TodoDto todoDto)
        {
            try
            {
                var todo = await _repository.GetByIdAsync(todoDto.Id);
                if (todo == null)
                {
                    throw new Exception("Todo not found");
                }

                todo.Title = todoDto.Title;
                todo.Description = todoDto.Description;
                todo.IsCompleted = todoDto.IsCompleted;

                await _repository.UpdateAsync(todo);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error In Updating todo item", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error In Deleting todo item", ex);
            }
        }
    }
}