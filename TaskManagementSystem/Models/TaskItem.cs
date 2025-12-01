namespace TaskManagementSystem.Models;

public class TaskItem
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public string UserId { get; set; }
    public bool IsCompleted { get; set; }

    public TaskItem(string title, string description, DateTime deadline, string userId)
    {
        Title = title;
        Description = description;
        Deadline = deadline;
        UserId = userId;
        IsCompleted = false;
    }
}
