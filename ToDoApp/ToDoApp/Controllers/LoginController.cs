using System;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Controllers
{
    public class LoginController:Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
