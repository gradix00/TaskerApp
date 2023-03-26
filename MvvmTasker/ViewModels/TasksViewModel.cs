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
        private const string _filePath = "C:/Users/50kos/Music/db.db";
        private ObservableCollection<TaskDataItem> _tasks = new BindableCollection<TaskDataItem>();
        private string _title;
        private string _description;
        private DateTime _creationDate;

        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        public ObservableCollection<TaskDataItem> Tasks
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
            _tasks.Clear();

            DatabaseProvider database = new DatabaseProvider(_filePath);
            var loadedData = new string[0];
            try
            {      
                loadedData = database.GetAllData("*", "Tasks");
            }
            catch (Exception ex) 
            {
                Tasks.Add(CreateTaskUI("brak zadań!",null, DateTime.Now));
                Console.WriteLine(ex.Message); 
            };

            foreach (var task in loadedData)
            {
                string[] data = task.Split(',');
                var newTask = CreateTaskUI(data[0], data[1], DateTime.Parse(data[2]));
                Tasks.Add(newTask);
            }
        }

        public void RemoveTask()
        {
            DatabaseProvider database = new DatabaseProvider(_filePath);
            foreach (var task in _tasks)
            {
                if (task.IsSelected)
                {
                    database.DeleteData("Title", task.Title, "Tasks");
                }
            }
            LoadTasks();
        }

        private TaskDataItem CreateTaskUI(string title, string description, DateTime date)
        {
            return new TaskDataItem()
            {
                Title = title,
                Description = description,
                CreationDate = date
            };
        }
    }
}
