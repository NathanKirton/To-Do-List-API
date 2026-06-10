using GameAPI.Models;
using GameAPI.Services;

namespace GameAPI.Services
{
    public class ToDoService : IToDoService
    {
        private readonly List<ToDoItem> _toDo = new List<ToDoItem>();
        private int _nextId = 1;

        public List<ToDoItem> GetAllTasks()
        {
            return _toDo;
        }

        public ToDoItem? GetTaskById(int id)
        {
            return _toDo.FirstOrDefault(t => t.Id == id);
        }

        public ToDoItem AddTask(ToDoItem task)
        {
            task.Id = _nextId++;
            _toDo.Add(task);
            return task;
        }

        public ToDoItem? UpdateTask(int id, ToDoItem updatedTask)
        {
            var existingTask = _toDo.FirstOrDefault(t => t.Id == id);

            if (existingTask == null) {
                return null;
            }
            else {
                existingTask.Title = updatedTask.Title;
                existingTask.IsComplete = updatedTask.IsComplete;
                return existingTask;
            }
        }

        public bool DeleteTask(int id) {
            var task = _toDo.FirstOrDefault(t =>t.Id == id);

            if (task == null)
            {
                return false;
            }
            _toDo.Remove(task);
            return true;

        }
    }
}
