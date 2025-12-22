using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
                Status=Models.TaskStatus.Todo

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
                Status = Models.TaskStatus.Todo
            };
            taskItems.Add(task);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (taskItems.Count == 0) return NotFound();

            var result = taskItems
                .Where(i => i.Id == id).FirstOrDefault();
                

            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,TaskItem taskItem)
        {
            if (id <= 0) return BadRequest();

            var findTask = taskItems.Find(i => i.Id == id);
            if (findTask == null) return NotFound();

            findTask.Title = taskItem.Title;
            findTask.Status = taskItem.Status;

            return Ok(findTask);
        }


    }
}
