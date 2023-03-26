using Caliburn.Micro;
using System;

namespace MvvmTasker.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        private string _title;

		public string Title
		{
			get => _title;
			set 
			{ 
				_title = value;
				NotifyOfPropertyChange(() => Title);
			}
		}


		public MainViewModel()
		{
			_title = "Tasker";
            ActivateItemAsync(new TasksViewModel());
        }

        public void OpenTasks()
        {
            ActivateItemAsync(new TasksViewModel());
        }

		public void OpenCreatorNewTask()
		{
			ActivateItemAsync(new CreatorNewTaskViewModel());
		}
    }
}
