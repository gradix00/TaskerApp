using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System;
using System.Windows.Media;
using MvvmTasker.Helpers;
using System.Windows;

namespace MvvmTasker.ViewModels
{
    public class TasksViewModel : Screen
    {
        private ObservableCollection<StackPanel> _tasks = new BindableCollection<StackPanel>();

        public ObservableCollection<StackPanel> Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
            }
        }

        public TasksViewModel()
        {
            LoadTasks();
        }

        public void LoadTasks()
        {
            DatabaseProvider database = new DatabaseProvider("C:/Users/50kos/Music/db.db");
            var loadedData = new string[0];
            try
            {      
                loadedData = database.GetAllData("*", "Tasks");
            }
            catch (Exception ex) 
            {
                Tasks.Add(CreateTaskUI(null, "Brak zadań"));
                Console.WriteLine(ex.Message); 
            };

            foreach (var task in loadedData)
            {
                string[] data = task.Split(',');
                var newTask = CreateTaskUI(data[0], data[1], DateTime.Parse(data[2]));
                Tasks.Add(newTask);
            }
        }

        private StackPanel CreateTaskUI(string title, string description, DateTime date)
        {
            StackPanel panel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Background = new SolidColorBrush(Colors.CornflowerBlue),
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };

            TextBlock titleBox = new TextBlock()
            {
                Text = title,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            TextBlock desBox = new TextBlock()
            {
                Text = description,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            TextBlock dateBox = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right
            };

            if (date == null)
                dateBox.Text = string.Empty;
            else
                dateBox.Text = date.ToString();

            panel.Children.Add(titleBox);
            panel.Children.Add(desBox);
            panel.Children.Add(dateBox);
            return panel;
        }

        private StackPanel CreateTaskUI(string title, string description)
        {
            StackPanel panel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Background = new SolidColorBrush(Colors.CornflowerBlue),
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };

            TextBlock titleBox = new TextBlock()
            {
                Text = title,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            TextBlock desBox = new TextBlock()
            {
                Text = description,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            panel.Children.Add(titleBox);
            panel.Children.Add(desBox);
            return panel;
        }
    }
}
