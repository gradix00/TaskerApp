using Caliburn.Micro;
using MvvmTasker.Helpers;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace MvvmTasker.ViewModels
{
    public class TasksViewModel : Screen
    {
        private static string _filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TaskerData";
        private const string _fileName = "Tasker.db";

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
            CreateFileDatabase();
            LoadTasks();
        }

        private void CreateFileDatabase()
        {
            DatabaseProvider database = new DatabaseProvider(_filePath, _fileName);
            database.CreateDatabase("Tasker");
            database.CreateTable("Tasks", "Id INT AUTO_INCREMENT, Title TEXT, Description TEXT, CreationDate DATETIME");
        }

        public void LoadTasks()
        {
            _tasks.Clear();

            DatabaseProvider database = new DatabaseProvider(_filePath, _fileName);
            var loadedData = new string[0];
            try
            {
                loadedData = database.GetAllData("*", "Tasks");
            }
            catch (Exception ex)
            {
                Tasks.Add(CreateTaskUI("brak zadań!", null, DateTime.Now));
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
            DatabaseProvider database = new DatabaseProvider(_filePath, _fileName);
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
