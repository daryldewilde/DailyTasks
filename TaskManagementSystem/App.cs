using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.LifecycleEvents;
using System;

namespace TaskManagementSystem
{
    public class App : Application
    {
        public App()
        {
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            return new Window(new Pages.RegisterPage());
        }
    }
}
