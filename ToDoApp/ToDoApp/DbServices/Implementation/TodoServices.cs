using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Constants;
using ToDoApp.DbServices.Interfaces;
using ToDoApp.Dtos;
using ToDoApp.Models;

namespace ToDoApp.DbServices.Implementation
{
    public class TodoServices : ITodoServices
    {
        private readonly ApplicationDbContext _dbContext;
        public TodoServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TodoDto>> Get()
        {
            try
            {
                var result = await _dbContext.Todos
                    .AsNoTracking()
                    .Select(i => new TodoDto
                    {
                        Id=i.Id,
                        Name=i.Name,
                        CreatedById=i.CreatedById,
                        CreatedOn=i.CreatedOn,
                        UpdatedById=i.UpdatedById,
                        UpdatedOn=i.UpdatedOn
                    }).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public async Task<TodoDto> GetById(int id)
        {
            try
            {
                var resultInDb = await _dbContext.Todos.SingleAsync(i => i.Id == id);
                var todoDto = new TodoDto()
                {
                    Id = resultInDb.Id,
                    Name = resultInDb.Name,
                };
                return todoDto;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<ResponseMessageDto> Save(TodoDto dto)
        {
            try
            {
                var model = new Todo()
                {
                    Name = dto.Name,
                    CreatedOn = DateTime.Now,
                    CreatedById = 1,
                };
                await _dbContext.Todos.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return new ResponseMessageDto()
                {
                    Success = true,
                    SuccessMessage = StaticStrings.TodoSuccess,
                    Failure = false,
                    FailureMessage = string.Empty
                };
            }
            catch (Exception ex)
            {
                new ResponseMessageDto()
                {
                    Success = false,
                    SuccessMessage = string.Empty,
                    Failure = true,
                    FailureMessage = StaticStrings.TodoFailure
                };
                throw ex;
            }
        }

        public async Task<ResponseMessageDto> Update(TodoDto dto)
        {
            try
            {
                var todo = new Todo() { Id = dto.Id };
                _dbContext.Todos.Attach(todo);
                todo.Name = dto.Name;
                todo.UpdatedById = 1;
                todo.UpdatedOn = DateTime.UtcNow;
                await _dbContext.SaveChangesAsync();
                return new ResponseMessageDto()
                {
                    Id=dto.Id,
                    Success = true,
                    SuccessMessage = StaticStrings.TodoSuccess,
                    Failure = false,
                    FailureMessage = string.Empty
                };
            }
            catch (Exception ex)
            {
                new ResponseMessageDto()
                {
                    Success = false,
                    SuccessMessage = string.Empty,
                    Failure = true,
                    FailureMessage = StaticStrings.TodoFailure
                };
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}
