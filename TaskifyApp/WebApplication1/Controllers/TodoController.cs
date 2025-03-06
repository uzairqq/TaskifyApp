using Microsoft.AspNetCore.Mvc;
using TaskifyAPI.Models;
using System.Linq;

namespace TaskifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TaskifyDbContext _context;

        public TodoController(TaskifyDbContext context)
        {
            _context = context;
        }

        // Get all todos
        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = _context.Todos.ToList();
            return Ok(todos);
        }

        // Get a single todo by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entity = _context.Todos.Find(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // Create a new todo
        [HttpPost]
        public IActionResult Post([FromBody] Todo todo)
        {
            if (todo == null)
            {
                return BadRequest("Todo cannot be null");
            }

            _context.Todos.Add(todo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Todo todo)
        {
            var entity = _context.Todos.Find(id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.Title = todo.Title;
            entity.DueDate = todo.DueDate;
            entity.IsCompleted = todo.IsCompleted;
            entity.Description = todo.Description;
            entity.Status = todo.Status;
            entity.IsUpdated = todo.IsUpdated;
            entity.IsDeleted = todo.IsDeleted;
            entity.UserId = todo.UserId;

            _context.SaveChanges();
            return Ok(entity);
        }

        // Delete a todo
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _context.Todos.Find(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(entity);
            _context.SaveChanges();
            return NoContent();
        }
    }
}