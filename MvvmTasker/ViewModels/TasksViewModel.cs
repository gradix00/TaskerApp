using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System;

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

        public void LoadTasks()
        {
            throw new NotImplementedException();
        }
    }
}
