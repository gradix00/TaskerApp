using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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


        public void OpenSettings()
        {
            //MessageBox.Show("works!");
            StackPanel stc = new StackPanel()
            {
                Height = 50,
                Background = new SolidColorBrush(Colors.CornflowerBlue)
            };
            TextBlock txt = new TextBlock()
            {
                Text = "nowe zadanie"
            };
            stc.Children.Add(txt);
            _tasks.Add(stc);
        }
    }
}
