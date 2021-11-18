using Microsoft.AspNetCore.Mvc;

namespace Todo_App.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
