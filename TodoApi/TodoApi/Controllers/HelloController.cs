using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        public string SayHello()
        {
            return "Hello Uzair! 🎉 Tumhari pehli API chal gayi.";
        }
    }
}
