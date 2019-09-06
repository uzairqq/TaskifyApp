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

        public async Task<IActionResult> Index()
        {
            var dto = new TodoDto();
            var result = await _todoServices.Get();
            dto.Todos = result;
            return View(dto);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(TodoDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

              	if (dto.Id == 0)
                    await _todoServices.Save(dto);
                else
                    await _todoServices.Update(dto);
                return RedirectToAction("Index");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var resultInDb =await _todoServices.GetById(id);
                resultInDb.Todos = await _todoServices.Get();
                return View("Index", resultInDb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }


        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _todoServices.Get();
                return View("Index", result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _todoServices.Delete(id);
                if (result.Success)
                    return RedirectToAction("Index");
                else
                    return BadRequest();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


    }
}