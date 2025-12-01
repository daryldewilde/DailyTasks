using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services;

public class TaskService
{
    private List<TaskItem> tasks = new();

    public void AddTask(TaskItem task) => tasks.Add(task);

    public List<TaskItem> GetTasksForUser(string userId) =>
        tasks.Where(t => t.UserId == userId).ToList();

    public List<TaskItem> GetCompletedTasks(string userId) =>
        tasks.Where(t => t.UserId == userId && t.IsCompleted).ToList();

    public List<TaskItem> GetFutureTasks(string userId) =>
        tasks.Where(t => t.UserId == userId && t.Deadline > DateTime.Now && !t.IsCompleted).ToList();
}
