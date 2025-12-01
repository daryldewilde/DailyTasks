using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TaskManagementSystem.Services;

namespace TaskManagementSystem
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Arial.ttf", "Arial");
                });

            builder.Services.AddSingleton<TaskService>();
            builder.Services.AddSingleton<MemberService>();

            return builder.Build();
        }
    }
}

