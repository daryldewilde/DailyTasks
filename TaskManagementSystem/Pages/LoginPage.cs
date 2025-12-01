using Microsoft.Maui.Controls;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Pages;

public class LoginPage : ContentPage
{
    private readonly Entry idEntry = new Entry { Placeholder = "Enter your Member ID" };
    private readonly Label resultLabel = new Label();

    public LoginPage()
    {
        var loginButton = new Button { Text = "Login" };
        loginButton.Clicked += OnLoginClicked;

        Content = new VerticalStackLayout
        {
            Padding = 30,
            Children = { new Label { Text = "Login", FontSize = 24 }, idEntry, loginButton, resultLabel }
        };
    }

    private void OnLoginClicked(object? sender, EventArgs e)
    {
        var id = idEntry.Text?.Trim();
        var member = LibraryService.Instance.MemberService.Login(id!);
        if (member == null)
        {
            resultLabel.Text = "Invalid ID.";
            return;
        }

        Application.Current!.MainPage = new MainPage(member.MemberId);
    }
}
