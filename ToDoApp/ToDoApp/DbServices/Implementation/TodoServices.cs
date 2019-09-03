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
                throw new Exception();
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
                throw;
            }
        }
    }
}
