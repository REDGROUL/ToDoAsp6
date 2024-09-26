using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoAsp.Dao.Service;
using ToDoAsp.Models;

namespace ToDoAsp.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class TaskController : Controller
    {
        private TasksService _taskService;
        private readonly UserManager<IdentityUser> _userManager;

        public TaskController(TasksService tasksService, UserManager<IdentityUser> userManager)
        {
            _taskService = tasksService;
            _userManager = userManager;
        }

        [HttpPost("newTask")]
        public IActionResult newTaskAsync([FromBody] Tasks task)
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (task == null)
            {
                return BadRequest("Task data is null.");
            }

            if(userid == null)
            {
                return Unauthorized();
            }

            task.OwnerId = userid;

            _taskService.NewTask(task);

            return Json(task);


        }

        [HttpGet("all")]
        public List<Tasks> GetAllTasks()
        {
            var userid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return _taskService.GetAllTasks(userid);
        }


        [HttpDelete("{id}")]
        public IActionResult DropTasks(int id)
        {
            _taskService.DeleteTask(new Tasks() {Id = id });
            return Ok(new { id });
        }
    }
}
