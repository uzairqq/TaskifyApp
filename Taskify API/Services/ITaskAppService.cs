using Microsoft.AspNetCore.Mvc;
using Taskify_API.Dto;

namespace Taskify_API.Services
{
    public interface ITaskAppService
    {
        Task<ResponseMessageDto> PostAsync(CreateUpdateTaskDto input);
        Task<ResponseMessageDto> PutAsync(int id, CreateUpdateTaskDto input);
        Task<List<GetTaskListDto>> GetListAsync();
        Task<GetTaskDto> GetByIdAsync(int id);
        Task<ResponseMessageDto> DeleteAsync(int id);
    }
}
