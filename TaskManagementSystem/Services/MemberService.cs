using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services;

public class MemberService
{
    private readonly List<Member> members = new();

    public Member Register(string name)
    {
        var memberId = $"{name.ToLower()}{members.Count + 1}";
        var member = new Member(name, memberId);
        members.Add(member);
        return member;
    }

    public Member? Login(string memberId) =>
        members.FirstOrDefault(m => m.MemberId == memberId);
}
