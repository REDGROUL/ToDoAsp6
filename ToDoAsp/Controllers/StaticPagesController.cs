using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToDoAsp.Controllers
{
    public class StaticPagesController : Controller
    {
        public IActionResult Auth()
        {
            return View();
        }

        public IActionResult Reg()
        {
            return View();
        }

        [Authorize]        
        public IActionResult Tasks()
        {
            return View();
        }
    }
}
