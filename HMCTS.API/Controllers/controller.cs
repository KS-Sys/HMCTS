using Microsoft.AspNetCore.Mvc;
using HMCTS.logic; 
using System.Collections.Generic;

/// to document api endpoints
namespace HMCTS.API.Controllers
{
    [Route("api/[controller]")] // This makes the address: localhost:xxxx/api/tasks
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        /// <summary>
        /// this is a method to get all tasks that are stored in the database and return them as JSON data.
        /// the html website returns a table that is populated with all the tasks including the newly created one.
        /// </summary>
        /// <returns></returns>
        // 1. GET: api/tasks
        [HttpGet]
        public IActionResult GetAll()
        {
            List<TaskModel> tasks = _service.GetAllTasks();
            return Ok(tasks);
        }

        /// <summary>
        /// this is a POST method to create a new task in the database using the data provided in the request body.
        /// the spec suggested that the task scheduler only needs to create tasks, so i have not implemented update or delete methods.
        /// although i do have the interfaces and methods in the logic layer should i wish to expand the project in the future.
        /// some of the methods are actually working but in the test harness console only.
        /// </summary>
        /// <param name="newTask"></param>
        /// <returns></returns>
        // 2. POST: api/tasks
        [HttpPost]
        public IActionResult Create([FromBody] TaskModel newTask)
        {
            _service.Create_Task(newTask);
            return Ok("Task Created Successfully");
        }

        /// <summary>
        /// this is a method to get all overdue tasks from the database and return them as JSON data, but i did not complete this part of the project.
        /// </summary>
        /// <returns></returns>
        // 3. GET: api/tasks/overdue
        [HttpGet("overdue")]
        public IActionResult GetOverdue()
        {
            TaskService service = new TaskService();
            var overdue = service.CheckOverDueTask();
            return Ok(overdue);
        }

        /// <summary>
        /// Deletes the task with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the task to delete.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the delete operation. Returns <see
        /// cref="NotFoundResult"/> if the task does not exist, <see cref="OkObjectResult"/> if the task was deleted
        /// successfully, or <see cref="StatusCodeResult"/> with status code 500 if an error occurred during deletion.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TaskModel delete = new TaskModel();
            delete.TaskID = id;

            int result = _service.Delete_Task(delete);

            if (result > 0)
            {
                return Ok($"Task {id} deleted");
            }
            else if (result == 0)
            {
                return NotFound($"Task {id} Error finding task");
            }
            else
            {
                return StatusCode(500, "task not found");
            }

        }
    }
}