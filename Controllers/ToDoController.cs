using GameAPI.Services;
using Microsoft.AspNetCore.Mvc;
using GameAPI.Models;

namespace GameAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public ActionResult<List<ToDoItem>> GetAllTasks()
        {
            return Ok(_toDoService.GetAllTasks());
        }

        [HttpGet("{id}")]
        public ActionResult<ToDoItem> GetTaskById(int id)
        {
            var task = _toDoService.GetTaskById(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public ActionResult<ToDoItem> AddTask(ToDoItem newTask)
        {
            var createdTask = _toDoService.AddTask(newTask);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public ActionResult<ToDoItem> UpdateTask(int id, ToDoItem updatedTask)
        {

            var task = _toDoService.UpdateTask(id, updatedTask);

            if (task == null)
                return NotFound();

            return Ok(task);

        }


        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            var deleted = _toDoService.DeleteTask(id);

            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
