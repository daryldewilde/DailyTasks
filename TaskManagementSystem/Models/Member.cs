namespace TaskManagementSystem.Models;

public class Member
{
    public string Name { get; set; }
    public string MemberId { get; set; }

    public Member(string name, string memberId)
    {
        Name = name;
        MemberId = memberId;
    }
}
