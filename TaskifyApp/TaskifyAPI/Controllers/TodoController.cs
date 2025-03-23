using Microsoft.AspNetCore.Mvc;
using TaskifyAPI.Models;
using System.Linq;
using TaskifyAPI.Services.Interface;
using TaskifyAPI.Dtos;

namespace TaskifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoServices _todoServices;

        public TodoController(ITodoServices todoServices)
        {
            _todoServices = todoServices;
        }

        // Get all todos
        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var tasks = await _todoServices.GetAllTodos();
            return Ok(tasks);
        }

        // Get a single todo by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            var task = await _todoServices.GetTodoById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        // Create a new todo
        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] TodoDto todoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _todoServices.AddTodo(todoDto);
            return CreatedAtAction(nameof(GetTodoById), new { id = todoDto.Id }, todoDto);
        }
        // Update a todo
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] TodoDto todoDto)
        {
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _todoServices.UpdateTodo(id, todoDto);
            return NoContent();
        }

        // Delete a todo
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            await _todoServices.DeleteTodo(id);
            return NoContent();
        }
    }
}