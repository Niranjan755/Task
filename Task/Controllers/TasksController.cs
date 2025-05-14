using Microsoft.AspNetCore.Mvc;
using SimpleTaskManagerAPI.Data;
using SimpleTaskManagerAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskData _taskData;

        public TasksController(TaskData taskData)
        {
            _taskData = taskData;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskItem>> GetTasks()
        {
            return Ok(_taskData.GetAllTasks());
        }

        [HttpGet("{id}")]
        public ActionResult<TaskItem> GetTask(int id)
        {
            var task = _taskData.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public ActionResult<TaskItem> CreateTask(TaskItem task)
        {
            _taskData.AddTask(task);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskItem task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            var existingTask = _taskData.GetTaskById(id);
            if (existingTask == null)
            {
                return NotFound();
            }

            _taskData.UpdateTask(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var existingTask = _taskData.GetTaskById(id);
            if (existingTask == null)
            {
                return NotFound();
            }

            _taskData.DeleteTask(id);
            return NoContent();
        }
    }
}