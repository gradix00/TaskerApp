using Caliburn.Micro;
using System.Windows;

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
	}
}
