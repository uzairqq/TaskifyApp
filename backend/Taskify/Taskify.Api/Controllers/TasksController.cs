using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Taskify.Api.Models;

namespace Taskify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        static List<TaskItem> taskItems = new List<TaskItem>()
        {
            new TaskItem
            {
                Id=1,
                Title="Wash Car",
                Status=false

            }
        };
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(taskItems);
        }
        [HttpPost]
        public IActionResult Post(TaskItem taskItem)
        {
            var newId = (taskItems.Count == 0) ? 1 : taskItems.Max(x => x.Id) + 1;

            var task = new TaskItem
            {
                Id = newId,
                Title = taskItem.Title,
                Status = taskItem.Status

            };
            taskItems.Add(task);
            return Ok(task);
        }

    }
}
