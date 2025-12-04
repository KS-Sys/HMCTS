using Microsoft.AspNetCore.Mvc;
using HMCTS.logic; 
using System.Collections.Generic;

namespace HMCTS.API.Controllers
{
    [Route("api/[controller]")] // This makes the address: localhost:xxxx/api/tasks
    [ApiController]
    public class TasksController : ControllerBase
    {
        // 1. GET: api/tasks
        [HttpGet]
        public IActionResult GetAll()
        {
            TaskService service = new TaskService();
            List<TaskModel> tasks = service.GetAllTasks();
            return Ok(tasks); // "Ok" sends back HTTP 200 and the JSON data
        }

        // 2. POST: api/tasks
        [HttpPost]
        public IActionResult Create([FromBody] TaskModel newTask)
        {
            TaskService service = new TaskService();
            service.Create_Task(newTask);
            return Ok("Task Created Successfully");
        }

        // 3. GET: api/tasks/overdue
        [HttpGet("overdue")]
        public IActionResult GetOverdue()
        {
            TaskService service = new TaskService();
            var overdue = service.CheckOverDueTask();
            return Ok(overdue);
        }
    }
}