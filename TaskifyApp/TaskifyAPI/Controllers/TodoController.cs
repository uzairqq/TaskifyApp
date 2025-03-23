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
        private readonly ILogger<TodoController> _logger;
        public TodoController(ITodoServices todoServices, ILogger<TodoController> logger)
        {
            _todoServices = todoServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            try
            {
                _logger.LogInformation("Fetching all Todos.");
                var tasks = await _todoServices.GetAllTodos();
                _logger.LogInformation("Returning all Todos.");
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching todos");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            try
            {
                _logger.LogInformation("Fetching todo with ID {TodoId}", id);
                var task = await _todoServices.GetTodoById(id);
                _logger.LogInformation("Returning todo with ID {TodoId}", id);
                if (task == null) return NotFound();
                return Ok(task);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching todo with ID {TodoId}", id);
                return StatusCode(500, "An unexpected error occurred.");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] TodoDto todoDto)
        {
            try
            {
                _logger.LogInformation("Creating a new todo.");
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _todoServices.AddTodo(todoDto);

                _logger.LogInformation("Returning a new todo.");
                return CreatedAtAction(nameof(GetTodoById), new { id = todoDto.Id }, todoDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while Adding Todo");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] TodoDto todoDto)
        {
            try
            {
                _logger.LogInformation("Updating todo with ID {TodoId}", id);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingTodo = await _todoServices.GetTodoById(id);
                if (existingTodo == null)
                {
                    _logger.LogWarning("Todo with ID {TodoId} not found.", id);
                    return NotFound($"Todo with ID {id} not found.");
                }

                await _todoServices.UpdateTodo(id, todoDto);
                _logger.LogInformation("Updated todo with ID {TodoId}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while Updating Todo");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            try
            {
                _logger.LogInformation("Deleting todo with ID {TodoId}", id);

                var existingTodo = await _todoServices.GetTodoById(id);
                if (existingTodo == null)
                {
                    _logger.LogWarning("Todo with ID {TodoId} not found.", id);
                    return NotFound($"Todo with ID {id} not found.");
                }

                await _todoServices.DeleteTodo(id);
                _logger.LogInformation("Todo with ID {TodoId} Deleted successfully", id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while Deleting Todo with ID {TodoId} ",id);
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}