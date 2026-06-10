using GameAPI.Models;


namespace GameAPI.Services
{
    public interface IToDoService
    {
        List<ToDoItem> GetAllTasks();
        ToDoItem? GetTaskById(int Id);
        ToDoItem AddTask(ToDoItem newTask);
        ToDoItem? UpdateTask(int Id,ToDoItem UpdateTask);
        bool DeleteTask(int Id);
    }
}
