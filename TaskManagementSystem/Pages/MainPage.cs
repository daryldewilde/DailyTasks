using Microsoft.Maui.Controls;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Pages;

public class MainPage : ContentPage
{
    private readonly string userId;
    private readonly ListView taskList;
    private readonly Picker tabPicker;

    public MainPage(string userId)
    {
        this.userId = userId;

        var pageTitle = new Label
        {
            Text = "Task Manager",
            FontSize = 28,
            HorizontalOptions = LayoutOptions.Center,
            HorizontalTextAlignment = TextAlignment.Center
        };

        tabPicker = new Picker
        {
            ItemsSource = new List<string> { "All Tasks", "Future Tasks", "Completed Tasks" },
            SelectedIndex = 0
        };
        tabPicker.SelectedIndexChanged += OnTabChanged;

        taskList = new ListView
        {
            HasUnevenRows = true,
            ItemTemplate = new DataTemplate(() =>
            {
                var title = new Label { FontAttributes = FontAttributes.Bold };
                title.SetBinding(Label.TextProperty, "Title");

                var deadline = new Label();
                deadline.SetBinding(Label.TextProperty, new Binding("Deadline", stringFormat: "Due: {0:d}"));

                var completed = new CheckBox();
                completed.SetBinding(CheckBox.IsCheckedProperty, "IsCompleted");
                completed.CheckedChanged += (s, e) =>
                {
                    var task = ((CheckBox)s).BindingContext as TaskItem;
                    task!.IsCompleted = e.Value;
                };

                var stack = new HorizontalStackLayout
                {
                    Padding = 10,
                    Children = { completed, new VerticalStackLayout { Children = { title, deadline } } }
                };

                var viewCell = new ViewCell { View = stack };
                viewCell.BindingContextChanged += (s, e) =>
                {
                    var cell = (ViewCell)s;
                    if (cell.BindingContext is TaskItem task)
                        completed.BindingContext = task;
                };

                return viewCell;
            })
        };

        var titleEntry = new Entry { Placeholder = "Task Title" };
        var descEntry = new Entry { Placeholder = "Task Description" };
        var deadlinePicker = new DatePicker { MinimumDate = DateTime.Today };

        var addButton = new Button { Text = "Add Task" };
        addButton.Clicked += (s, e) =>
        {
            if (string.IsNullOrWhiteSpace(titleEntry.Text)) return;

            var task = new TaskItem(titleEntry.Text!, descEntry.Text ?? "", deadlinePicker.Date, userId);
            LibraryService.Instance.TaskService.AddTask(task);
            titleEntry.Text = "";
            descEntry.Text = "";
            RefreshTasks();
        };

        Content = new ScrollView
        {
            Content = new VerticalStackLayout
            {
                Padding = 20,
                Spacing = 15,
                Children =
                {
                    pageTitle,
                    tabPicker,
                    taskList,
                    new Label { Text = "Create New Task", FontSize = 20 },
                    titleEntry, descEntry, deadlinePicker, addButton
                }
            }
        };

        RefreshTasks();
    }

    private void RefreshTasks()
    {
        var taskService = LibraryService.Instance.TaskService;

        taskList.ItemsSource = tabPicker.SelectedIndex switch
        {
            1 => taskService.GetFutureTasks(userId),
            2 => taskService.GetCompletedTasks(userId),
            _ => taskService.GetTasksForUser(userId)
        };
    }

    private void OnTabChanged(object? sender, EventArgs e) => RefreshTasks();
}
