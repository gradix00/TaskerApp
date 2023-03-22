using Caliburn.Micro;
using MvvmTasker.Helpers;
using System.Windows;

namespace MvvmTasker.ViewModels
{
    public class CreatorNewTaskViewModel : Screen
    {
        private string _name;
        private string _description;

        public string Name
        {
            get => _name;
            set { _name = value; }
        }

        public string Description
        {
            get => _description;
            set { _description = value; }
        }

        public TaskData ReturnTaskData()
        {
            return new TaskData
            {
                Name = this.Name,
                Description = this.Description,
                CreationDate = System.DateTime.Now
            };
        }
    }
}
