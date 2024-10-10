using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskifyApp.Dto;
using TaskifyApp.Services;

namespace TaskifyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoDto>>> GetAllAsync()
        {
            var todos = await _todoService.GetAllAsync();
            return Ok(todos);
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public async Task<ActionResult<TodoDto>> GetByIdAsync(int id)
        {
            var todo = await _todoService.GetByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<TodoDto>> AddAsync(TodoDto todoDto)
        {
            await _todoService.AddAsync(todoDto);
            return CreatedAtRoute("GetTodo", new { controller = "Todo", id = todoDto.Id }, todoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, TodoDto todoDto)
        {
            await _todoService.UpdateAsync(todoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _todoService.DeleteAsync(id);
            return NoContent();
        }
    }
}

