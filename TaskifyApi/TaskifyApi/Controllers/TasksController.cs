using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskifyApi.Data;
using TaskifyApi.Dto;
using TaskifyApi.Models;

namespace TaskifyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        //Get: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> Get()
        {
            return await _context.TaskItems.ToListAsync();
        }

        //Get: api/tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task == null) return NotFound();
            return task;
        }

        //Post: api/tasks
        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask(CreateTaskDto taskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = new TaskItem
            {
                Title = taskDto.Title,
                IsCompleted = false
            };


            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        //Put: api/tasks/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(int id,UpdateTaskDto taskDto)
        {

            if (id != taskDto.Id)
                return BadRequest("ID mismatch");


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = await _context.TaskItems.FindAsync(id);
            if (task == null)
                return NotFound();

            task.Title = taskDto.Title;
            task.IsCompleted = taskDto.IsCompleted;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Delete: api/tasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskItem>> DeleteTask(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task == null) return NotFound();
            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
