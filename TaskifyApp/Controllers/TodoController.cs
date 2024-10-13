using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TaskifyApp.Dto;
using TaskifyApp.Models;
using TaskifyApp.Repository;
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
            try
            {
                var todos = await _todoService.GetAllAsync();
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse
                {
                    Message = ex.Message,
                    StatusCode = ((int)HttpStatusCode.InternalServerError).ToString(),
                    ErrorDetails = ex.StackTrace
                });
            }

        }

        [HttpGet("{id}", Name = "GetTodo")]
        public async Task<ActionResult<TodoDto>> GetByIdAsync(int id)
        {
            try
            {
                var todo = await _todoService.GetByIdAsync(id);
                if (todo == null)
                {
                    return NotFound();
                }
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse
                {
                    Message = ex.Message,
                    StatusCode = ((int)HttpStatusCode.InternalServerError).ToString(),
                    ErrorDetails = ex.StackTrace
                });
            }

        }

        [HttpPost]
        public async Task<ActionResult<TodoDto>> AddAsync(TodoDto todoDto)
        {
            try
            {
                await _todoService.AddAsync(todoDto);
                return CreatedAtRoute("GetTodo", new { controller = "Todo", id = todoDto.Id }, todoDto);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse
                {
                    Message = ex.Message,
                    StatusCode = ((int)HttpStatusCode.InternalServerError).ToString(),
                    ErrorDetails = ex.StackTrace
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, TodoDto todoDto)
        {
            try
            {
                await _todoService.UpdateAsync(todoDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse
                {
                    Message = ex.Message,
                    StatusCode = ((int)HttpStatusCode.InternalServerError).ToString(),
                    ErrorDetails = ex.StackTrace
                });
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _todoService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorResponse
                {
                    Message = ex.Message,
                    StatusCode = ((int)HttpStatusCode.InternalServerError).ToString(),
                    ErrorDetails = ex.StackTrace
                });
            }
        }

        [HttpGet("Pagination")]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter filter)
        {
            var pagedResponse = await _todoService.GetTodosAsync(filter);
            return Ok(pagedResponse);
        }
    }
}

