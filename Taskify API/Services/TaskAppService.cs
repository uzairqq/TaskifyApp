using Microsoft.EntityFrameworkCore;
using Taskify_API.Dto;
using Taskify_API.Repository;
using Task = Taskify_API.Models.Task;

namespace Taskify_API.Services
{
    public class TaskAppService : ITaskAppService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskAppService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ResponseMessageDto> PostAsync(CreateUpdateTaskDto input)
        {
            try
            {
                try
                {
                    var task = new Task()
                    {
                        Name = input.Name,
                        Description = input.Description,
                        Priority = input.Priority,
                        CreatedDateAndTime = DateTime.Now,
                        DueDateAndTime = DateTime.Now
                    };
                    var taskResult = await _taskRepository.PostAsync(task);
                    return new ResponseMessageDto
                    {
                        Id = taskResult.Id,
                        SuccessMessage = "Task created successfully",
                        IsSuccess = true
                    };
                }
                catch (Exception ex)
                {
                    return new ResponseMessageDto
                    {
                        IsFailed = true,
                        FailureMessage = ex.Message
                    };
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<ResponseMessageDto> PutAsync(int id, CreateUpdateTaskDto input)
        {
            try
            {
                var task = await _taskRepository.GetByIdAsync(id);
                if (task == null)
                {
                    return new ResponseMessageDto
                    {
                        FailureMessage = "Task not found",
                        IsSuccess = false
                    };
                }

                task.Name = input.Name;
                task.Description = input.Description;
                task.Priority = input.Priority;
                task.CreatedDateAndTime = input.CreatedDateAndTime;
                task.DueDateAndTime = input.DueDateAndTime;
                var taskResult = await _taskRepository.PutAsync(task);
                return new ResponseMessageDto
                {
                    Id = taskResult.Id,
                    SuccessMessage = "Task updated successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseMessageDto
                {
                    IsFailed = true,
                    FailureMessage = ex.Message
                };
                throw;
            }
        }
        public async Task<ResponseMessageDto> DeleteAsync(int id)
        {
            try
            {
                var task = await _taskRepository.GetByIdAsync(id);
                if (task == null)
                {
                    return new ResponseMessageDto
                    {
                        FailureMessage = "Task not found",
                        IsSuccess = false
                    };
                }

                await _taskRepository.DeleteAsync(task);

                return new ResponseMessageDto
                {
                    SuccessMessage = "Task deleted successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseMessageDto
                {
                    IsFailed = true,
                    FailureMessage = ex.Message
                };
                throw;
            }
        }
        public async Task<GetTaskDto> GetByIdAsync(int id)
        {
            try
            {
                var task = await _taskRepository.GetByIdAsync(id);
                if (task == null)
                {
                    return null;
                }

                return new GetTaskDto
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    Priority = task.Priority,
                    CreatedDateAndTime = task.CreatedDateAndTime,
                    DueDateAndTime = task.DueDateAndTime,
                    IsComplete = task.IsComplete
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<List<GetTaskListDto>> GetListAsync()
        {
            try
            {
                var tasks = await _taskRepository.GetListAsync();
                var taskList = new List<GetTaskListDto>();
                foreach (var task in tasks)
                {
                    taskList.Add(new GetTaskListDto
                    {
                        Id = task.Id,
                        Name = task.Name,
                        Description = task.Description,
                        Priority = task.Priority,
                        CreatedDateAndTime = task.CreatedDateAndTime,
                        DueDateAndTime = task.DueDateAndTime
                    });
                }

                return taskList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }




    }
}
