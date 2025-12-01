using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services;

public class LibraryService
{
    private static LibraryService? instance;
    public static LibraryService Instance => instance ??= new LibraryService();

    public MemberService MemberService { get; }
    public TaskService TaskService { get; }

    private LibraryService()
    {
        MemberService = new MemberService();
        TaskService = new TaskService();
    }
}
