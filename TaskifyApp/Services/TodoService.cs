// TodoService.cs
using TaskifyApp.Dto;
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
            var todos = await _repository.GetAllAsync();
            return todos.Select(todo => new TodoDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted
            }).ToList();
        }

        public async Task<TodoDto> GetByIdAsync(int id)
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

        public async Task AddAsync(TodoDto todoDto)
        {
            var todo = new TodoItem
            {
                Title = todoDto.Title,
                Description = todoDto.Description,
                IsCompleted = todoDto.IsCompleted
            };

            await _repository.AddAsync(todo);
            todoDto.Id = todo.Id;
            //return todoDto;
        }

        public async Task UpdateAsync(TodoDto todoDto)
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

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}