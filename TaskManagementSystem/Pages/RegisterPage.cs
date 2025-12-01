using Microsoft.Maui.Controls;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Pages;

public class RegisterPage : ContentPage
{
    private readonly Entry nameEntry = new Entry { Placeholder = "Enter your name" };
    private readonly Label resultLabel = new Label { TextColor = Colors.Green, FontSize = 16, HorizontalOptions = LayoutOptions.Center };
    private readonly Label titleLabel = new Label { Text = "Register", FontSize = 28, HorizontalTextAlignment = TextAlignment.Center };

    public RegisterPage()
    {
        var registerButton = new Button { Text = "Register", FontSize = 18 };
        registerButton.Clicked += OnRegisterClicked;

        Content = new VerticalStackLayout
        {
            Padding = new Thickness(30, 60),
            Spacing = 15,
            Children =
            {
                titleLabel,
                nameEntry,
                registerButton,
                resultLabel
            }
        };
    }

    private async void OnRegisterClicked(object? sender, EventArgs e)
    {
        var name = nameEntry.Text?.Trim();

        if (string.IsNullOrEmpty(name) || name.Any(char.IsDigit))
        {
            resultLabel.Text = "Name cannot contain numbers, special characters, or blank spaces."; 
            resultLabel.TextColor = Colors.Red;
            return;
        }

        var member = LibraryService.Instance.MemberService.Register(name);

        resultLabel.TextColor = Colors.Green;
        resultLabel.Text = $"Registered successfully!\nYour Member ID: {member.MemberId}";

        await Task.Delay(5000); 

        Application.Current!.MainPage = new LoginPage();
    }
}
