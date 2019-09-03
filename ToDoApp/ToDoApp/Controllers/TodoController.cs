using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.DbServices.Interfaces;
using ToDoApp.Dtos;

namespace ToDoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoServices _todoServices;
        public TodoController(ITodoServices todoServices)
        {
            _todoServices = todoServices;
        }

        public IActionResult Index()
        {
            var dto = new TodoDto();
            return View(dto);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] TodoDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result =await _todoServices.Save(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}